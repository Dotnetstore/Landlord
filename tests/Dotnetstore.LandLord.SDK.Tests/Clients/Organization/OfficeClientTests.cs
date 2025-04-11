using System.Net;
using System.Text;
using Dotnetstore.LandLord.SDK.Clients.Organization;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace Dotnetstore.LandLord.SDK.Tests.Clients.Organization;

public class OfficeClientTests
{
    private readonly List<OfficeResponse> _officeResponses = [];

    public OfficeClientTests()
    {
        _officeResponses.Add(new OfficeResponse
        {
            Id = Guid.Parse("33ACC885-045B-46C7-9914-6C293D449F02"),
            Name = "Office 1",
            CorporateId = null
        });
        _officeResponses.Add(new OfficeResponse
        {
            Id = Guid.Parse("3EE5D3FE-5D7C-46C8-B073-E4ABB749BE86"),
            Name = "Office 2",
            CorporateId = "123456-7890"
        });
    }
    
    [Fact]
    public void GetAllAsync_ShouldReturnListOfOffices()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(_officeResponses), Encoding.UTF8, "application/json")
            });
        
        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://localhost:5001")
        };
        
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory
            .Setup(f => f.CreateClient("LandLord"))
            .Returns(httpClient);

        var officeClient = new OfficeClient(mockHttpClientFactory.Object);
        
        // Act
        var result = officeClient.GetAllAsync(CancellationToken.None).Result;
        
        // Assert
        using (new AssertionScope())
        {
            result.OfficeResponse.Should().HaveCount(2);
            result.httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnOfficeResponse()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString().ToLower().Contains("33ACC885-045B-46C7-9914-6C293D449F02".ToLower())),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(_officeResponses[0]), Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory
            .Setup(f => f.CreateClient("LandLord"))
            .Returns(httpClient);

        IOfficeClient officeClient = new OfficeClient(mockHttpClientFactory.Object);

        // Act
        var result = await officeClient.GetByIdAsync(Guid.Parse("33ACC885-045B-46C7-9914-6C293D449F02"), CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.OfficeResponse.Should().NotBeNull();
            result.OfficeResponse.Id.Should().Be(_officeResponses[0].Id);
            result.OfficeResponse.Name.Should().Be(_officeResponses[0].Name);
            result.OfficeResponse.CorporateId.Should().Be(_officeResponses[0].CorporateId);
            result.httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
    
    [Fact]
    public async Task CreateAsync_ShouldReturnSuccessResponse()
    {
        // Arrange
        var createRequest = new CreateOfficeRequest
        {
            Name = "New Office",
            CorporateId = "987654-3210"
        };

        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri!.ToString().ToLower().Contains("api/v1/organization/offices") &&
                    req.Content!.ReadAsStringAsync().Result.ToLower().Contains("new office")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonConvert.SerializeObject(new OfficeResponse
                {
                    Id = Guid.NewGuid(),
                    Name = createRequest.Name,
                    CorporateId = createRequest.CorporateId
                }), Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory
            .Setup(f => f.CreateClient("LandLord"))
            .Returns(httpClient);

        IOfficeClient officeClient = new OfficeClient(mockHttpClientFactory.Object);

        // Act
        var result = await officeClient.CreateAsync(createRequest, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.httpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
    
    [Fact]
    public async Task UpdateAsync_ShouldReturnSuccessResponse()
    {
        // Arrange
        var updateRequest = new UpdateOfficeRequest
        {
            Name = "Updated Office",
            CorporateId = "123456-7890"
        };

        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put &&
                    req.RequestUri!.ToString().ToLower().Contains("api/v1/organization/offices") &&
                    req.Content!.ReadAsStringAsync().Result.ToLower().Contains("updated office")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory
            .Setup(f => f.CreateClient("LandLord"))
            .Returns(httpClient);

        IOfficeClient officeClient = new OfficeClient(mockHttpClientFactory.Object);

        // Act
        var result = await officeClient.UpdateAsync(Guid.Parse("33ACC885-045B-46C7-9914-6C293D449F02"),  updateRequest, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.httpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldReturnSuccessResponse()
    {
        // Arrange
        var officeId = Guid.Parse("33ACC885-045B-46C7-9914-6C293D449F02");

        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Delete &&
                    req.RequestUri!.ToString().ToLower().Contains($"api/v1/organization/offices/{officeId}".ToLower())),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://localhost:5001")
        };

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory
            .Setup(f => f.CreateClient("LandLord"))
            .Returns(httpClient);

        IOfficeClient officeClient = new OfficeClient(mockHttpClientFactory.Object);

        // Act
        var result = await officeClient.DeleteAsync(officeId, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.httpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}