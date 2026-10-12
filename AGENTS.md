# AGENTS.md

.NET Standard 2.0 REST client for the inRiver PIM API. NuGet package `inRiverCommunity.Rest.Client`. Two projects in `src/`: `InRiver.Rest.Lib` (library) and `InRiver.Rest.Lib.Tests` (NUnit, net6.0).

## Commands

```sh
dotnet build ./src          # also produces the .nupkg (GeneratePackageOnBuild=true)
dotnet test ./src           # whole test project (what CI runs)
dotnet test src/InRiver.Rest.Lib.Tests --filter "FullyQualifiedName~HttpOverride"   # single suite
```

CI (`build.yml`) also runs SonarCloud via `dotnet sonarscanner` + `dotnet-coverage` — not needed for local work.

## Architecture

- `InRiverRestClient` is the only public entry point (`InRiver.Rest.Lib/Client/InRiverRestClient.cs`). Consumers always start with `new InRiverRestClient(apiKey, ...)`.
- Nine generated API classes in `Api/` (Entity, Channel, Link, Media, Model, Query, Syndicate, System, Workarea), reached as lazy singleton properties on the client.
- **Only interfaces are public.** `EntityApi`, `ApiClient`, `Serializer`, `RestClientFactory`, etc. are `internal` — add to the interface, not just the class, or consumers can't see it.
- Request flow: API method → `ApiClient.CallApi(Async)` → `RestClientFactory` (swaps in an injected `HttpClient` if set) → `Serializer` (Newtonsoft) → `ApiResponse<T>`. Errors ≥400 throw `ApiException`.

## Generated code — don't hand-edit structure

`Api/*.cs` and `Model/*.cs` are OpenAPI-generator output: `localVar*` variable names, `<para>`-heavy doc comments, `#region` layout, and a fixed four-method pattern per endpoint (`X`, `XWithHttpInfo`, `XAsync`, `XAsyncWithHttpInfo`). `EntityApi.cs` is ~4100 lines. Keep the pattern when adding a method; never "refactor" the structure or strip doc comments.

## Gotchas

- **Sync methods block**: `ApiClient.CallApi` does `.Result` (sync-over-async). Use `Async` variants; don't add new sync call sites.
- **Match the upstream typo'd names**: `ExeternalUrlFileModel` (typo is in the official spec), `IinRiverClient`, `EntityApi.EntityUploadMediaFromUrlWithHttpInfo` (mismatched with `UploadMediaFromUrl`). Don't "fix" them.
- Models are `[DataContract]`/`[DataMember]` with hand-coded `ToJson()`/`Equals`/`GetHashCode` — when adding a field, update those too.
- Auth is the `X-inRiver-APIKey` header, set in `Configuration.DefaultHeader`. Base path defaults to `https://apieuw.productmarketingcloud.com`.
- Retry/polly is consumer-side: inject a pre-configured `HttpClient` via `Configuration.HttpClientOverride` (see README). No retry lives in this repo.
- Test internals work because of `InternalsVisibleTo("InRiver.Rest.Lib.Tests")` and `InternalsVisibleTo("DynamicProxyGenAssembly2")` (Moq) — keep these if you move assemblies.

## Release

Version lives in `src/InRiver.Rest.Lib/InRiver.Rest.Lib.csproj` (currently 1.0.3). Tagging `vX.Y.Z` publishes to NuGet + GitHub Packages (`nuget.yml`); the tag version overrides the csproj via `/p:Version`. Bump the `<Version>` in the csproj for the next release.

## Tests

NUnit + FluentAssertions + Moq, in two flavors:
- `UnitTests/` — serializer, client plumbing, helpers, model serialization (pure unit tests).
- `FeatureTests/HttpOverrideTests/` — real endpoint paths stubbed with `JustEat.HttpClientInterception`, proving the `HttpClientOverride` path. Use this pattern to test new endpoint wiring without a network.