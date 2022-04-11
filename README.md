# inriver-rest-client
.NET client for InRiver PIM Rest API. Client targets .NET Standard 2.0. <br/> <br/>
Created off inRiver [Swagger](https://apieuw.productmarketingcloud.com/swagger/ui/index#/) with [Swagger tools](https://swagger.io/)

# Installing via NuGet

```
Install-Package inRiverCommunity.Rest.Client
```
# Example Usage

## Getting entity data
```csharp
# Creating a rest client with appropriate REST API key
var client = new InRiverRestClient("your-api-key");

# Using api to get entity summary
var entitySummaryModel = await client.EntityApi.GetEntitySummaryAsync(10);
```

## Searching for data
```csharp
# Creating a rest client with appropriate REST API key
var client = new InRiverRestClient("your-api-key");

# Creating a query model
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
