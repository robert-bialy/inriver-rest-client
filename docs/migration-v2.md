# Migrating from 1.x to 2.0

## Scope and compatibility

The NuGet ID remains `inRiverCommunity.Rest.Client`; the target remains `netstandard2.0`. .NET Framework 4.7.2+ is recommended. The test runner targets .NET 8, which does not change the library's consumer requirements.

2.0 uses the repository's supplied `swagger.json` as a fixed reference, with all 223 operations across Channel, DSA, Entity, Extension, HtmlTemplate, Link, LinkRule, Logs, Media, Model, Query, Syndicate, System, and Workarea. It does not claim to cover an independently fetched live specification.

Recompile consumers and update mocks implementing API interfaces. This major version changes method signatures, model constructors/types, and the interface surface. There is no database/data migration. To roll back, restore the previous package version and corresponding consumer code; rollback cannot undo API writes already sent to inriver.

## HTTP transport

- RestSharp and the old public `Services.IRestClient` adapter are removed. Configure handlers/retries through an injected `HttpClient` instead.
- Newtonsoft.Json remains the serializer (13.0.3). Dynamic JSON values remain `object`/Newtonsoft tokens; date-looking strings inside arbitrary JSON stay strings.
- Dispose `InRiverRestClient` when finished. Injected HTTP clients are **not** disposed or reconfigured by the library. Share long-lived clients or obtain them from `IHttpClientFactory`.
- `Configuration.Timeout` is a per-request timeout in milliseconds (default 100000; -1 disables it). An injected HTTP client's own timeout may expire sooner. Cancellation/timeout raises `OperationCanceledException`; HTTP failures remain `ApiException` with the original status and body. Network failures retain error code 0.
- Async methods now accept a trailing optional `CancellationToken`. Synchronous methods remain available but block; their exceptions are no longer wrapped in `AggregateException` by `.Result`.
- Configure the client before first use. Concurrent requests are supported, but concurrent changes to configuration are not. Configure shared HTTP clients without a conflicting default API-key header.

```csharp
using var client = new InRiverRestClient(apiKey, basePath, httpClient);
var result = await client.EntityApi.FetchDataAsync(
    new FetchObjectsModel(new List<int> { 10 }, "EntitySummary,FieldValues"),
    cancellationToken);
```

## Endpoint and model changes

- Entity creation now calls `/api/v1.0.1/entities:createnew`.
- Use `ModelApi.GetAllEntityTypesV101Async` instead of `GetAllEntityTypesAsync`. The response is `EntityTypeModelV2`; `FieldTypes` contains field type IDs, not embedded field definitions. Fetch definitions through `GetAllFieldTypesForEntityTypeAsync`.
- `EntityTypeModel` and `FieldTypeModel` are replaced by `EntityTypeModelV2` and `FieldTypeModelV2` from the supplied schema. `CompletenessDetailsGroupModel` and `CompletenessDetailsRuleModel` become `CompletenessGroupDetailsModel` and `CompletenessRuleDetailModel`.
- Model properties/constructor order now follow the Swagger. Prefer named constructor arguments or object initializers when updating consumers. For example, `LinkModel.linkEntityId` precedes `index`; `FieldSetModel.Name` and `Description` are strings while creation/update models carry localized dictionaries.
- Required numeric path parameters are non-nullable. Optional parameters omit their query entries when null. All methods still have `X`, `XWithHttpInfo`, `XAsync`, and `XAsyncWithHttpInfo` variants (including the retained `EntityUploadMediaFromUrlWithHttpInfo` spelling).
- Bodies that Swagger marks optional can be omitted. Array/dictionary bodies use the parameter name `body`; typed bodies use the schema name in camelCase. Named-argument callers may need updating.
- `date-time` schema values use `DateTimeOffset`; UUID values use `Guid`. Optional value-type properties remain nullable to distinguish omission from explicit false/zero. Read-only schema properties have private setters and deserialize through Newtonsoft.
- `QueryModel` now supports `DataCriteriaOperator` and `Objects`. With `Objects = "count"`, `EntityListModel.EntityIds` can be null: use `Count` directly.
- Snapshot, language-role, upsert, extension, link-rule, and other new models are generated from the schema. Open-ended response shapes (DSA insights, extension statistics) remain dictionaries of arbitrary JSON rather than invented DTOs. Untyped extension responses support JSON and plain text.
- Required nullable fields and documented clear/unassign values preserve JSON null. Optional update properties otherwise omit null; empty lists remain empty lists. In particular, omitted language-role `Languages` preserves assignments, while an empty list removes them.
- Optional values are left unset instead of copying server defaults into every request. This prevents omitted fields from becoming accidental updates. Permissions, request limits, pagination, and server-side business validation are not duplicated in the client. Pagination is explicit; the client does not automatically fetch additional pages.

See [generation notes](../tools/README.md) for duplicate operation naming and source-specification inconsistencies. API XML comments carry upstream endpoint descriptions, including replacement semantics and permissions.

## Validation

```sh
python tools/generate.py --check
dotnet build ./src --configuration Release
dotnet test ./src --configuration Release
```

Contract tests intercept requests locally for every endpoint and all four variants, checking methods, paths, authentication, query encoding, request JSON, success statuses, and response shapes. Focused tests cover null/empty/false distinctions, errors, cancellation, timeouts, shared-client ownership, dynamic JSON, and concurrent API access. No live inriver credentials are required.
