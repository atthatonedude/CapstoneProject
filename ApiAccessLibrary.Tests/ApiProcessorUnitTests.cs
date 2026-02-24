using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIAccessLibrary;
using APIAccessLibrary.Model;
using Xunit;

namespace APIAccessLibrary.Tests
{
    public class ApiProcessorUnitTests
    {
        [Fact]
        public async Task CreateUserAsync_UsesExpectedUrl_AndReturnsTrueOnSuccess()
        {
            var modal = new UserLoginModal
            {
                UserName = "testuser",
                UserPassword = "password"
            };

            var handler = new TestHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK));
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7281")
            };

            var result = await ApiProcessor.CreateUserAsync(modal, client);

            Assert.True(result);
            Assert.NotNull(handler.LastRequest);
            Assert.Equal("/api/usercreation", handler.LastRequest!.RequestUri!.PathAndQuery);
        }

        [Fact]
        public async Task LoginUserAsync_BuildsQueryStringFromModel()
        {
            var modal = new UserLoginModal
            {
                UserName = "testuser",
                UserPassword = "password"
            };

            var handler = new TestHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK));
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7281")
            };

            var result = await ApiProcessor.LoginUserAsync(modal, client);

            Assert.True(result);
            Assert.NotNull(handler.LastRequest);
            Assert.Equal("/api/userlogin?username=testuser&password=password", handler.LastRequest!.RequestUri!.PathAndQuery);
        }

        [Fact]
        public async Task GetItemsAsync_ReturnsItemsOnSuccess()
        {
            var requestModel = new ItemModel { ItemPartNumber = 123 };

            var expectedItems = new List<ItemModel>
            {
                new ItemModel { ItemId = 1, ItemDescription = "Item1", ItemQuantity = 10, ItemPartNumber = 123 },
                new ItemModel { ItemId = 2, ItemDescription = "Item2", ItemQuantity = 5, ItemPartNumber = 123 }
            };

            var json = JsonSerializer.Serialize(expectedItems);

            var handler = new TestHttpMessageHandler(_ =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                return response;
            });

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7281")
            };

            var result = await ApiProcessor.GetItemsAsync(requestModel, client);

            Assert.Equal(2, result.Count);
            Assert.Equal(123, result[0].ItemPartNumber);
            Assert.Equal("/api/getitems?searchedpartnumber=123", handler.LastRequest!.RequestUri!.PathAndQuery);
        }

        [Fact]
        public async Task GetBuildableItemsAsync_ReturnsQuantityOnSuccess()
        {
            const int parentItemId = 42;
            const int expectedQty = 7;

            var json = JsonSerializer.Serialize(expectedQty);

            var handler = new TestHttpMessageHandler(_ =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                return response;
            });

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7281")
            };

            var result = await ApiProcessor.GetBuildableItemsAsync(parentItemId, client);

            Assert.Equal(expectedQty, result);
            Assert.Equal("/api/getmaxbuildqty?parentItemId=42", handler.LastRequest!.RequestUri!.PathAndQuery);
        }

        private sealed class TestHttpMessageHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> handlerFunc;

            public HttpRequestMessage? LastRequest { get; private set; }

            public TestHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handlerFunc)
            {
                this.handlerFunc = handlerFunc ?? throw new ArgumentNullException(nameof(handlerFunc));
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                LastRequest = request;
                return Task.FromResult(handlerFunc(request));
            }
        }
    }
}
