using EazyQuiz.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace EazyQuiz.Desktop.Admin;
public class ApiProvider
{
    private readonly IConfiguration _config;
    private readonly HttpClient _client;

    public ApiProvider(IConfiguration config)
    {
        _config = config;
        _client = new HttpClient() { BaseAddress = new Uri(_config["EazyQuizApiUrl"]) };
    }

    public UserResponse Authtenticate(UserAuth userAuth)
    {
        string myJson = JsonSerializer.Serialize(userAuth);

        var response = Task.Run(() => { return _client.GetAsync($"/api/Auth/GetUserByPassword?Email={userAuth.Email}&Password={userAuth.Password}"); }).Result;

        var responseDataString = Task.Run(() => { return response.Content.ReadAsStringAsync(); }).Result;
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseDataString);

        if (userResponse == null)
        {
            throw new Exception();
        }

        return userResponse;
    }

    public string Authtenticate1(UserAuth userAuth)
    {
        string myJson = JsonSerializer.Serialize(userAuth);

        var response = Task.Run(() => { return _client.GetAsync($"/api/Auth/GetUserByPassword?Email={userAuth.Email}&Password={userAuth.Password}"); }).Result;

        var responseDataString = Task.Run(() => { return response.Content.ReadAsStringAsync(); }).Result;

        return responseDataString;
    }
}
