using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EazyQuiz.Web.Api.Controllers;
/// <summary>
/// Контроллер работы с вопросами
/// </summary>
[Route("api/[controller]")]
[ApiController, Authorize]
public class QuestionsController : Controller
{
    /// <summary>
    /// <inheritdoc cref="DataContext"/>
    /// </summary>
    private readonly DataContext _dataContext;

    /// <summary>
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<QuestionsController> _log;

    public QuestionsController(DataContext dataContext, ILogger<QuestionsController> logger)
    {
        _dataContext = dataContext;
        _log = logger;
    }

    /// <summary>
    /// Получить все вопросы
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string GetAllQuestions()
    {
        var result = _dataContext.Questions.ToList();
        _log.LogInformation("GetAllQuestions");
        return JsonSerializer.Serialize(result);
    }

}
