using EazyQuiz.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace EazyQuiz.Desktop.Admin;
public class ApiProvider : IDisposable
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
        var response = Task.Run(() => { return _client.GetAsync($"/api/Auth/GetUserByPassword?Email={userAuth.Email}&Password={userAuth.Password}"); }).Result;

        string responseDataString = Task.Run(() => { return response.Content.ReadAsStringAsync(); }).Result;
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseDataString);

        if (userResponse == null)
        {
            throw new Exception();
        }

        return userResponse;
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    public void Registrate(UserRegister userRegister)
    {
        string json = JsonSerializer.Serialize(userRegister);

        var response = Task.Run(() => { return _client.PostAsync("api/Auth/RegisterNewPlayer", new StringContent(json, Encoding.UTF8, "application/json")); });

    }
}
