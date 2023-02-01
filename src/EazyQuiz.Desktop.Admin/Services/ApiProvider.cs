using EazyQuiz.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace EazyQuiz.Desktop.Admin;
/// <summary>
/// Работа с Апи EazyQuiz
/// </summary>
public class ApiProvider : IDisposable
{
    /// <summary>
    /// <inheritdoc cref="IConfiguration"/>
    /// </summary>
    private readonly IConfiguration _config;

    /// <summary>
    /// <inheritdoc cref="HttpClient"/>
    /// </summary>
    private readonly HttpClient _client;

    public ApiProvider(IConfiguration config)
    {
        _config = config;
        _client = new HttpClient() { BaseAddress = new Uri(_config["EazyQuizApiUrl"]) };
    }

    /// <summary>
    /// Авторизация пользователя 
    /// </summary>
    /// <param name="userAuth"></param>
    /// <returns>Объект <see cref="UserResponse"/> инфа о пользователе с JWT токеном</returns>
    /// <exception cref="ArgumentException">Пользователь не найден</exception>
    public UserResponse Authtenticate(UserAuth userAuth)
    {
        var response = Task.Run(() => { return _client.GetAsync($"/api/Auth/GetUserByPassword?Email={userAuth.Email}&Password={userAuth.Password}"); }).Result;

        string responseDataString = Task.Run(() => { return response.Content.ReadAsStringAsync(); }).Result;
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseDataString);

        if (userResponse == null)
        {
            throw new ArgumentException("Error in Deserialize");
        }

        return userResponse;
    }

    /// <summary>
    /// Регистрация новых игроков
    /// </summary>
    /// <param name="userRegister"></param>
    public void Registrate(UserRegister userRegister)
    {
        string json = JsonSerializer.Serialize(userRegister);

        var response = Task.Run(() => { return _client.PostAsync("api/Auth/RegisterNewPlayer", new StringContent(json, Encoding.UTF8, "application/json")); });

    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
