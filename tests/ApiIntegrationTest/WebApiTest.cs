using Microsoft.AspNetCore.Mvc.Testing;


namespace ApiIntegrationTest;

public class WebApiTest
{
    private readonly HttpClient _client;

    public WebApiTest()
    {
        var appFactory = new WebApplicationFactory<Program>();
        _client = appFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task Test1Async()
    {
        var response = await _client.GetAsync("");
        String str = await response.Content.ReadAsStringAsync();

       Assert.True(str == "Hello World!");
    }
}