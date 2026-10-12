[![Downloads](https://img.shields.io/nuget/dt/inRiverCommunity.Rest.Client.svg)](https://www.nuget.org/packages/inRiverCommunity.Rest.Client/)[![Build and test](https://github.com/robert-bialy/inriver-rest-client/actions/workflows/build.yml/badge.svg)](https://github.com/robert-bialy/inriver-rest-client/actions/workflows/build.yml)
# inriver-rest-client
.NET client for InRiver PIM Rest API. Client targets .NET Standard 2.0. <br/> <br/>
Created off inRiver [Swagger](https://apieuw.productmarketingcloud.com/swagger/ui/index#/) with [Swagger tools](https://swagger.io/)

Version 2 covers all **223 operations in 14 API groups** and the **128 endpoint-referenced schemas** in the checked-in `swagger.json`. It uses `HttpClient` and Newtonsoft.Json and supports .NET Framework consumers via .NET Standard 2.0 (.NET Framework 4.7.2+ recommended).

This is a breaking release: see [migration notes](docs/migration-v2.md).

# Installing via NuGet

```
Install-Package inRiverCommunity.Rest.Client
```
# Example Usage

## Getting entity data
```csharp
// Creating a rest client with appropriate REST API key
using var client = new InRiverRestClient("your-api-key");

// Using api to get entity summary
var entitySummaryModel = await client.EntityApi.GetEntitySummaryAsync(10);
```

## Searching for data
```csharp
// Creating a rest client with appropriate REST API key
using var client = new InRiverRestClient("your-api-key");

// Creating a query model
var query = new QueryModel
            {
                SystemCriteria = new List<SystemCriterionModel>
                {
                    new SystemCriterionModel
                    {
                        Type = "EntityTypeId",
                        Operator = "Equal",
                        Value = "Product"
                    }
                }
            };

var products = await client.QueryApi.QueryAsync(query);
```
## Creating rest client with retry policy
```csharp
using InRiver.Rest.Lib.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

// Configuring named HttpClient with retry policy
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddHttpClient("inriver")
        .AddPolicyHandler(HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5))))
    .Build();

var httpClient = host.Services.GetRequiredService<IHttpClientFactory>().CreateClient("inriver");

// Creating a rest client with appropriate REST API key and pre-configured HttpClient
using var client = new InRiverRestClient("your-api-key", "https://apieuw.productmarketingcloud.com", httpClient);

```

## Cancellation and HTTP client ownership

```csharp
using var client = new InRiverRestClient("your-api-key");
var snapshot = await client.EntityApi.GetLatestSnapshotAsync(10, cancellationToken: cancellationToken);
var tags = await client.ModelApi.GetSnapshotTagsAsync(cancellationToken);
```

All asynchronous methods accept a trailing `CancellationToken`. Prefer asynchronous methods; synchronous variants block. `InRiverRestClient.Dispose()` releases only an internally created HTTP client. Injected clients remain caller-owned. API keys are attached to individual requests, not to shared `HttpClient.DefaultRequestHeaders`. Configure retries on the injected client; the library does not retry requests.

## Updating the Swagger client

Requires Python 3.10+ for generation and the .NET 8 SDK for building/tests. Python is not needed by package consumers or for a normal build.

```sh
python tools/generate.py
python tools/generate.py --check
dotnet build ./src --configuration Release
dotnet test ./src --configuration Release
```

Replace `swagger.json` with the intended upstream specification, regenerate, review the diff, and run the checks. The [generator documentation](tools/README.md) explains naming overrides, supported schemas, and templates. CI and release builds check that generated files match the supplied specification. HTTP contract tests cover every operation and all four method variants without making network calls.
