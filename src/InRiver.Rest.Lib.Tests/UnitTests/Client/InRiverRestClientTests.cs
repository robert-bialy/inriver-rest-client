using System.Net;
using FluentAssertions;
using InRiver.Rest.Lib.Client;
using InRiver.Rest.Lib.Model;
using JustEat.HttpClientInterception;
using NUnit.Framework;

namespace InRiver.Rest.Lib.Tests.UnitTests.Client
{
    [TestFixture]
    internal class InRiverRestClientTests
    {
        [Test]
        public async Task EntityApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.EntityApi.AddExternalUrlAsync(1, new ExeternalUrlFileModel("",""));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task ChannelApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.ChannelApi.EntityTypesAsync(1);
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task LinkApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.LinkApi.CreateLinkAsync(new LinkModel(1,true,"11",1,2,3,5));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task MediaApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.MediaApi.AddExternalUrlAsync(new ExternalUrlFileModelWithLink("aaa", "aaa", new ResourceLinkModel(1,"mm")));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task QueryApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.QueryApi.QueryAsync(new QueryModel(new List<SystemCriterionModel>(), new List<DataCriterionModel>(), new LinkCriterionModel()));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task SyndicateApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.SyndicateApi.SyndicationsAsync();
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task ModelApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.ModelApi.GetAllCvlValuesAsync("11");
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task SystemApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.SystemApi.AddUserRoleForSegmentAsync(1, new UserRoleModel("aa", "bb"));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        [Test]
        public async Task WorkareaApi_CreationIsThreadSafe()
        {
            var inRiverClient = GetInRiverRestClient();

            var tasks = Enumerable.Range(1, 5)
                .Select(async c =>
                {
                    await inRiverClient.WorkareaApi.CreateWorkareaAsync(new WorkareaCreationModel("11",true));
                });

            var action = async () => await Task.WhenAll(tasks);
            await action.Should().NotThrowAsync();
        }

        private static InRiverRestClient GetInRiverRestClient()
        {
            var http = new HttpClientInterceptorOptions();
            http.OnMissingRegistration += _ => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ReadOnlyMemoryContent(ReadOnlyMemory<byte>.Empty),
                Headers = { },
                RequestMessage = new HttpRequestMessage(),
                StatusCode = HttpStatusCode.OK,
                TrailingHeaders = { },
                Version = new Version(1, 0)
            });
            var client = http.CreateHttpClient();
            var inRiverClient = new InRiverRestClient("1", "http://localhost", client);
            return inRiverClient;
        }
    }
}
