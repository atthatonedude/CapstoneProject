using System.Collections.Generic;
using System.Threading.Tasks;
using APIAccessLibrary;
using APIAccessLibrary.Model;
using Xunit;

namespace APIAccessLibrary.Tests
{
    // These are integration tests: they expect the API at https://localhost:7281 to be running.
    public class ApiProcessorTests
    {
        [Fact]
        public async Task CreateUserAsync_WhenValidUser_ReturnsTrue()
        {
            // arrange
            var user = new UserLoginModal
            {
                UserName = "testuser",
                UserPassword = "TestPassword123!"
            };

            // act
            bool result = await ApiProcessor.CreateUserAsync(user);

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task LoginUserAsync_WhenValidCredentials_ReturnsTrue()
        {
            // arrange
            var user = new UserLoginModal
            {
                UserName = "testuser",
                UserPassword = "TestPassword123!"
            };

            // act
            bool result = await ApiProcessor.LoginUserAsync(user);

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetItemsAsync_WhenPartNumberExists_ReturnsNonEmptyList()
        {
            // arrange
            var searchModel = new ItemModel
            {
                // Use a part number that you know exists in your test database
                ItemPartNumber = 12345
            };

            // act
            List<ItemModel> items = await ApiProcessor.GetItemsAsync(searchModel);

            // assert
            Assert.NotNull(items);
            Assert.NotEmpty(items);
        }

        [Fact]
        public async Task GetItemsAsync_WhenPartNumberDoesNotExist_ReturnsEmptyList()
        {
            // arrange
            var searchModel = new ItemModel
            {
                // Use a part number you know does NOT exist
                ItemPartNumber = -1
            };

            // act
            List<ItemModel> items = await ApiProcessor.GetItemsAsync(searchModel);

            // assert
            Assert.NotNull(items);
            Assert.Empty(items);
        }

        [Fact]
        public async Task GetBuildableItemsAsync_WhenParentItemExists_ReturnsNonNegative()
        {
            // arrange
            int parentItemId = 1; // adjust to an ID that exists in your DB

            // act
            int qty = await ApiProcessor.GetBuildableItemsAsync(parentItemId);

            // assert
            Assert.True(qty >= 0);
        }
    }
}