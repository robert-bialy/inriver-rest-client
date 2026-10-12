# Client generation

`generate.py` is a repository-specific OpenAPI 3.0 generator using only Python 3.10+'s standard library. Its templates preserve this client's public interfaces, internal API implementations, four method variants, DataContract models, and shared HTTP transport. No Java, Node, or production generator dependency is required.

Run from any directory:

```sh
python tools/generate.py
python tools/generate.py --check
```

On Windows with the .NET Framework 4.7.2 targeting pack, verify runtime consumption with:

```sh
dotnet run --project tools/FrameworkSmoke --configuration Release
```

This small consumer checks HTTP injection, JSON null clearing, response deserialization, cancellation, and caller-owned client lifetime on .NET Framework. The Windows CI job runs it as well.

Inputs: root `swagger.json`, `tools/generate.py`, `tools/templates/*`.
Outputs: `src/InRiver.Rest.Lib/Api/*`, endpoint-referenced `Model/*`, `Client/IinRiverClient.cs`, `Client/InRiverRestClient.Apis.cs`, and `tools/operations.json` (operation-to-method inventory used by contract tests).

The script writes deterministically, ignores line-ending differences when checking, never changes the supplied Swagger, and removes stale API/model files only when they carry its generated header. Edit templates or generator mappings, not generated files. Keep transport, client constructors, configuration, and serialization changes in their non-generated files.

## Scope

The supported subset is the one used by the supplied spec: local schema references, object models, dictionaries, arrays, integer enums, primitives, arbitrary JSON, required/nullable/read-only properties, path parameters, form-style query parameters, JSON bodies, and a single success response per operation. Unsupported union/composition schemas, external references, parameter locations/styles, and duplicate C# operation names cause generation to fail. This is not a general-purpose OpenAPI generator.

Only schemas reachable from operations (including errors) are emitted. The 28 unreferenced Workflow/Workspace and other schemas in this snapshot are intentionally excluded. Schema formats `date-time` and `uuid` map to `DateTimeOffset` and `Guid`; plain strings remain strings. Optional value-type properties/parameters are nullable so omission remains distinct from explicit false/zero. Server defaults stay server-side. Required nullable properties and the explicit `INCLUDE_NULL` mapping emit JSON null, allowing clear/unassign operations.

## Upstream ambiguities

Operation IDs ending in `Async` have that suffix removed before generating the standard four variants. Repeated IDs across different API groups are harmless. The `NAMES` table resolves duplicates within a group:

| Endpoint | C# base method |
|---|---|
| GET channels/snapshottags | `GetChannelSnapshotTags` |
| PUT extensionmanager:restartservice | `RestartServicePut` (POST uses `RestartService`) |
| GET model/unusedfieldtypes | `GetUnusedFieldTypes` |
| DELETE model/restrictedfields:byfieldtype | `DeleteRestrictedFieldPermissionByFieldType` |
| GET workareafolderquery/{id} | `WorkareaFolderQueryById` |

`GetWorkareaFolderEntityIds` and `EntityUploadMediaFromUrlWithHttpInfo` retain their existing client spellings. Upstream typos such as `ExeternalUrlFileModel`, `SetExtensionApiKet`, and `GetSpecificationTemplatesields` remain intact.

The supplied document also has path keys differing only by parameter spelling (`fieldsetId` / `fieldSetId`, `connectorId` / `id`). Python preserves them case-sensitively and each HTTP operation is generated separately. Do not normalize these paths into a case-insensitive dictionary.

Schema shapes take precedence over prose/examples. For example, `LanguageRoleUpdateModel.name` is required despite partial-update prose; channel snapshot assignment uses `snapshotTag`, not the prose's `id`; extension statistics use an arbitrary JSON dictionary rather than their apparently copied DSA example. Permissions and environment feature checks remain server-side and errors preserve their original status/body.
