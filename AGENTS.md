# AGENTS.md

.NET Standard 2.0 REST client for the inRiver PIM API. NuGet package `inRiverCommunity.Rest.Client`. Two projects in `src/`: `InRiver.Rest.Lib` (library) and `InRiver.Rest.Lib.Tests` (NUnit, net8.0). The library supports .NET Framework consumers; 4.7.2+ is recommended.

## Commands

```sh
python tools/generate.py          # regenerate from checked-in swagger.json (Python 3.10+)
python tools/generate.py --check  # verify generated output matches inputs
dotnet build ./src          # also produces the .nupkg (GeneratePackageOnBuild=true)
dotnet test ./src           # whole test project (what CI runs)
dotnet test src/InRiver.Rest.Lib.Tests --filter "FullyQualifiedName~HttpOverride"   # single suite
dotnet run --project tools/FrameworkSmoke --configuration Release  # Windows + net472 targeting pack
```

CI (`build.yml`) checks generated output, builds and tests on Linux, and verifies .NET Framework consumption on Windows.

## Architecture

- `InRiverRestClient` is the only public entry point (`InRiver.Rest.Lib/Client/InRiverRestClient.cs`). Consumers always start with `new InRiverRestClient(apiKey, ...)`.
- Generated API classes in `Api/` are reached as lazy singleton properties in `Client/InRiverRestClient.Apis.cs`.
- **API groups expose public interfaces, internal implementations.** Generate both when adding endpoints. `ApiClient` and `Serializer` are concrete internal classes without interfaces.
- Request flow: API method → `ApiClient.CallApi(Async)` → `HttpClient` → `Serializer` (Newtonsoft) → `ApiResponse<T>`. Errors ≥400 throw `ApiException`; network failures use error code 0.

## Generated code — edit inputs, not output

The checked-in `swagger.json` is the authoritative contract. `tools/generate.py` uses Python's standard library and checked-in templates to generate `Api/*.cs`, endpoint-reachable `Model/*.cs`, client API properties/interfaces, and `tools/operations.json`. Unreferenced schemas are intentionally omitted.

Edit the specification, generator, or `tools/templates/`, then regenerate and run `--check`; never hand-edit generated output. Preserve `localVar*` names, XML docs, regions, and the four-method endpoint pattern (`X`, `XWithHttpInfo`, `XAsync`, `XAsyncWithHttpInfo`). Keep naming exceptions in `NAMES` and intentional null serialization in `INCLUDE_NULL`. Schema shapes take precedence over conflicting prose. See `tools/README.md` for supported constructs and ambiguities, and `docs/migration-v2.md` for consumer migration guidance.

## Gotchas

- **Sync methods block**: `ApiClient.CallApi` uses `.GetAwaiter().GetResult()`. Prefer `Async` variants; all accept a trailing `CancellationToken`. Preserve cancellation as `OperationCanceledException`, not `ApiException`.
- **Match the upstream typo'd names**: `ExeternalUrlFileModel` (typo is in the official spec), `IinRiverClient`, `EntityApi.EntityUploadMediaFromUrlWithHttpInfo` (mismatched with `UploadMediaFromUrl`). Don't "fix" them.
- Models use generated `[DataContract]`/`[DataMember]`, `ToJson()`, and member-based `Equals`/`GetHashCode`. Serializing the model inside equality caused a stack overflow during development; retain member-based equality.
- **Omitted is not cleared**: optional null properties generally disappear; required nullable and `INCLUDE_NULL` properties emit null for clear/unassign operations. Preserve explicit `false`, `0`, and empty arrays. Arbitrary JSON must retain date-looking strings as strings.
- Dispose `InRiverRestClient` to release its internally created `HttpClient`; injected clients remain caller-owned. Configure before first use; concurrent configuration mutation is unsupported.
- Auth is the `X-inRiver-APIKey` header, configured in `Configuration.DefaultHeader` and applied per request, never to shared `HttpClient.DefaultRequestHeaders`. Base path defaults to `https://apieuw.productmarketingcloud.com`.
- Retry/polly is consumer-side: inject a pre-configured `HttpClient` via `Configuration.HttpClientOverride` (see README). No retry lives in this repo.
- Test internals work because of `InternalsVisibleTo("InRiver.Rest.Lib.Tests")` and `InternalsVisibleTo("DynamicProxyGenAssembly2")` (Moq) — keep these if you move assemblies.

## Release

Version lives in `src/InRiver.Rest.Lib/InRiver.Rest.Lib.csproj`. Tagging `vX.Y.Z` publishes to NuGet + GitHub Packages (`nuget.yml`); the tag version overrides the csproj via `/p:Version`. Bump the `<Version>` in the csproj for the next release.

## Tests

NUnit + FluentAssertions + Moq, in two flavors:
- `UnitTests/` — serializer, client plumbing, helpers, model serialization (pure unit tests).
- `FeatureTests/HttpOverrideTests/` — endpoint paths stubbed with `JustEat.HttpClientInterception` or a local `HttpMessageHandler`, proving the injected-client path without a network. `SwaggerContractTests` covers every operation and all four method variants against the specification; preserve its coverage inventory check.
- Keep focused tests for semantics the specification cannot prove: omission/null/empty distinctions, cancellation, errors, dynamic JSON, and client ownership. `tools/FrameworkSmoke` verifies .NET Framework consumption; the .NET 8 test runner does not change the library's consumer requirements.
