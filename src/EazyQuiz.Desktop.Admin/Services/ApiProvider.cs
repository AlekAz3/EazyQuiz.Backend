using EazyQuiz.Cryptography;
using EazyQuiz.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;
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

    /// <summary>
    /// Адрес сервера 
    /// </summary>
    private readonly string _baseAdress;

    public ApiProvider(IConfiguration config)
    {
        _config = config;
        _baseAdress = _config["EazyQuizApiUrl"];
        _client = new HttpClient();
    }

    /// <summary>
    /// Авторизация пользователя 
    /// </summary>
    /// <param name="username">Ник</param>
    /// <param name="password">Пароль</param>
    /// <exception cref="ArgumentException">Пользователь не найден</exception>
    public UserResponse Authtenticate(string username, string password)
    {
        var salt = GetUserSaltByUsername(username);

        var hashPassword = PasswordHash.HashWithCurrentSalt(password, salt);

        var userAuth = new UserAuth(username, new UserPassword(hashPassword, salt));

        string json = JsonSerializer.Serialize(userAuth);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Auth/GetUserByPassword"),
            Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
        };

        var response = Task.Run(() => { return _client.SendAsync(request); }).Result;

        var responseBody = Task.Run(() =>
        {
            return response.Content.ReadAsStringAsync();
        }).Result;

        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseBody);

        if (userResponse == null)
        {
            throw new ArgumentException("Error in Deserialize");
        }

        return userResponse;
    }

    /// <summary>
    /// Получение соли по нику игрока
    /// </summary>
    /// <param name="userName">Ник</param>
    /// <returns>Соль</returns>
    /// <exception cref="Exception">Соль не найдена</exception>
    public string GetUserSaltByUsername(string userName)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Auth/GetUserSalt?userName={userName}"),
        };

        var response = Task.Run(() => { return _client.SendAsync(request); }).Result;

        var responseBody = Task.Run(() =>
        {
            return response.Content.ReadAsStringAsync();
        }).Result;

        if (responseBody == null)
        {
            throw new Exception();
        }
        return responseBody;
    }

    /// <summary>
    /// Регистрация нового игрока
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="username">Ник</param>
    /// <param name="age">Возраст</param>
    /// <param name="gender">Пол</param>
    /// <param name="country">Страна</param>
    internal void Registrate(string password, string username, int age, string gender, string country)
    {
        var user = new UserRegister()
        {
            UserName = username,
            Age = age,
            Gender = gender,
            Country = country,
            Password = PasswordHash.Hash(password)
        };

        string json = JsonSerializer.Serialize(user);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_baseAdress}/api/Auth/RegisterNewPlayer"),
            Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
        };

        var response = Task.Run(() => { return _client.SendAsync(request); });

    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
