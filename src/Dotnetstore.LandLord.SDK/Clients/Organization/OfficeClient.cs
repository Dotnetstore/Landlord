using System.Net.Http.Json;
using System.Text;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Dotnetstore.LandLord.SDK.Services;
using Newtonsoft.Json;

namespace Dotnetstore.LandLord.SDK.Clients.Organization;

public sealed class OfficeClient(IHttpClientFactory httpClientFactory) : IOfficeClient
{
    public async ValueTask<(IEnumerable<OfficeResponse> OfficeResponse, HttpResponseMessage httpResponseMessage)> GetAllAsync(CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient("LandLord");
        var response = await client.GetAsync(ApiEndpoints.V1.Organization.Office.GetAll, ct);
        var success = response.IsSuccessStatusCode;
        
        if (!success)
        {
            return ([], response);
        }
        
        var content = await response.Content.ReadAsStringAsync(ct);
        var result = JsonConvert.DeserializeObject<IEnumerable<OfficeResponse>>(content);
        return (result ?? [], response);
    }

    async ValueTask<(OfficeResponse OfficeResponse, HttpResponseMessage httpResponseMessage)> IOfficeClient.GetByIdAsync(Guid id, CancellationToken ct)
    {
        var url = ApiEndpoints.V1.Organization.Office.GetById.Replace("{id:guid}", id.ToString());
        var client = httpClientFactory.CreateClient("LandLord");
        var response = await client.GetAsync(url, ct);
        var success = response.IsSuccessStatusCode;
        
        if (!success)
        {
            return (new OfficeResponse(), response);
        }
        
        var content = await response.Content.ReadAsStringAsync(ct);
        var result = JsonConvert.DeserializeObject<OfficeResponse>(content);
        return (result, response);
    }

    async ValueTask<(OfficeResponse OfficeResponse, HttpResponseMessage httpResponseMessage)> IOfficeClient.CreateAsync(CreateOfficeRequest createOfficeRequest, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient("LandLord");
        var response = await client.PostAsJsonAsync(ApiEndpoints.V1.Organization.Office.Create, createOfficeRequest, ct);
        var success = response.IsSuccessStatusCode;
        
        if (!success)
        {
            return (new OfficeResponse(), response);
        }
        
        var content = await response.Content.ReadAsStringAsync(ct);
        var result = JsonConvert.DeserializeObject<OfficeResponse>(content);
        return (result, response);
    }

    async ValueTask<(bool IsSuccess, HttpResponseMessage httpResponseMessage)> IOfficeClient.UpdateAsync(Guid id, UpdateOfficeRequest updateOfficeRequest, CancellationToken ct)
    {
        using StringContent jsonContent = new(
            JsonConvert.SerializeObject(updateOfficeRequest),
            Encoding.UTF8,
            "application/json");
        var url = ApiEndpoints.V1.Organization.Office.Update.Replace("{id:guid}", id.ToString());
        var client = httpClientFactory.CreateClient("LandLord");
        var response = await client.PutAsync(url, jsonContent, ct);
        var success = response.IsSuccessStatusCode;
        
        return (success, response);
    }

    async ValueTask<(bool IsSuccess, HttpResponseMessage httpResponseMessage)> IOfficeClient.DeleteAsync(Guid id, CancellationToken ct)
    {
        var url = ApiEndpoints.V1.Organization.Office.Delete.Replace("{id:guid}", id.ToString());
        var client = httpClientFactory.CreateClient("LandLord");
        var response = await client.DeleteAsync(url, ct);
        var success = response.IsSuccessStatusCode;
        
        return (success, response);
    }
}