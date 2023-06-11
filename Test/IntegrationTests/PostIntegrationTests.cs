using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using MinimalApi.Endpoints;
using System.Net;
using System.Net.Http.Json;

namespace Test.IntegrationTests
{
    public class PostIntegrationTests
    {
        [Fact]
        public async Task GetPostAllTestAsync()
        {
            await using var application = new WebApplicationFactory<PostEndPointDefinitions>();

            using var client = application.CreateClient();
            using var response = await client.GetAsync("/api/v1/posts");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetPostByIdTestAsync(int id)
        {
            await using var application = new WebApplicationFactory<PostEndPointDefinitions>();

            using var client = application.CreateClient();
            using var response = await client.GetAsync($"/api/v1/posts/{id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostTestAsync()
        {
            await using var application = new WebApplicationFactory<PostEndPointDefinitions>();

            using var client = application.CreateClient();
            using var response = await client.PostAsJsonAsync("/api/v1/posts", new Post { Content = "xUnit 101" });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task PutTestAsync(int id)
        {
            await using var application = new WebApplicationFactory<PostEndPointDefinitions>();

            using var client = application.CreateClient();
            using var response = await client.PutAsJsonAsync($"/api/v1/posts/{id}", new Post { Content = "xUnit 101" });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async Task DeleteTestAsync(int id)
        {
            await using var application = new WebApplicationFactory<PostEndPointDefinitions>();

            using var client = application.CreateClient();
            using var response = await client.DeleteAsync($"/api/v1/posts/{id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
