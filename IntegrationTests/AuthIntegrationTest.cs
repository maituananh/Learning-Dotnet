using API.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace IntegrationTests.Auths;

public class AuthIntegrationTest(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetToken_Return_Ok()
    {
        // Arrange
        var request = new AuthRequest
        {
            Username = "1111aaaa1111",
            Password = "Abc@1234"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/auth/token", request);

        var body = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK, body);
    }
}
