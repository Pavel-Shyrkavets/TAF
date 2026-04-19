using System.Net;
using TAF.Business.Model;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TAF.Core.API;

public class UserClient
{
    private readonly IRestClient _client;

    public UserClient(string endpoint) 
    {
        var serializerOptions = 
            new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        _client = new RestClient(
            options: new() { BaseUrl = new(endpoint) },
            configureSerialization: s => s.UseSystemTextJson(serializerOptions));
    }

    public async Task<List<User>> GetUsersAsync() 
    { 
        var request = new RestRequest("/users"); 
        var response = await _client.GetAsync<List<User>>(request); 

        return response; 
    }

    public async Task<HttpStatusCode> GetUsersStatusCode()
    {
        var request = new RestRequest("/users");
        var response = await _client.ExecuteAsync(request);

        return response.StatusCode;
    }
}
