using EazyQuiz.Cryptography;
using EazyQuiz.Models.DTO;
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
    public async Task<UserResponse> Authtenticate(string username, string password)
    {
        var salt = await GetUserSaltByUsername(username);

        var hashPassword = PasswordHash.HashWithCurrentSalt(password, salt);

        var userAuth = new UserAuth()
        {
            Username = username,
            PasswordHash = hashPassword
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Auth?Username={userAuth.Username}&PasswordHash={userAuth.PasswordHash}"),
        };

        var response = await _client.SendAsync(request);

        var responseBody = await response.Content.ReadAsStringAsync();

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
    public async Task<string> GetUserSaltByUsername(string userName)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Auth/{userName}"),
        };

        var response = await _client.SendAsync(request);

        var responseBody = await response.Content.ReadAsStringAsync();

        if (responseBody == null)
        {
            throw new ArgumentNullException(paramName: nameof(userName));
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
    internal async Task Registrate(string password, string username, int age, string gender, string country)
    {
        var user = new UserRegister()
        {
            Username = username,
            Age = age,
            Gender = gender,
            Country = country,
            Password = PasswordHash.Hash(password)
        };

        string json = JsonSerializer.Serialize(user);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_baseAdress}/api/Auth"),
            Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
        };

        await _client.SendAsync(request);
    }

    /// <summary>
    /// Проверка на существующей ник 
    /// </summary>
    /// <param name="userName">Ник</param>
    /// <returns>true - если ник НЕ уникален</returns>
    /// <exception cref="ArgumentNullException">Нулл</exception>
    public async Task<bool> CheckUsername(string userName)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Auth/{userName}"),
        };

        var response = await _client.SendAsync(request);

        var responseBody = await response.Content.ReadAsStringAsync();

        if (responseBody == null)
        {
            throw new ArgumentNullException(paramName: nameof(userName));
        }

        if (responseBody == "true")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Получить вопрос и ответы с сервера
    /// </summary>
    public async Task<QuestionWithAnswers> GetQuestion(string token)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseAdress}/api/Questions/GetQuestion"),
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

        var response = await _client.SendAsync(request);

        var responseBody = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<QuestionWithAnswers>(responseBody) ?? new QuestionWithAnswers();
    }

    /// <summary>
    /// Отправить на сервер новый вопрос
    /// </summary>
    /// <param name="quws">Вопрос в <see cref="QuestionWithoutId"/></param>
    public async Task SendNewQuestion(QuestionWithoutId quws)
    {
        string json = JsonSerializer.Serialize(quws);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_baseAdress}/api/Questions/Add"),
            Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
        };
        var response = await _client.SendAsync(request);
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
