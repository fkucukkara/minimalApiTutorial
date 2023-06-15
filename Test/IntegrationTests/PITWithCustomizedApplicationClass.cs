using MinimalApi.Endpoints;
using System.Net;
using Test.IntegrationTests.Helpers;

namespace Test.IntegrationTests;

public class PITWithCustomizedApplicationClass : IClassFixture<TestWebApplicationFactory<PostEndPointDefinitions>>
{
    private readonly TestWebApplicationFactory<PostEndPointDefinitions> _factory;
    public PITWithCustomizedApplicationClass(TestWebApplicationFactory<PostEndPointDefinitions> factory)
    {
        _factory = factory;
    }


    [Fact]
    public async Task Get_Post_ReturnAll()
    {
        using var client = _factory.CreateClient();
        using var response = await client.GetAsync("/api/v1/posts");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}