using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EazyQuiz.Web.Api;
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
    public async Task<string> GetAllQuestions()
    {
        var result = await _dataContext.Questions.ToListAsync();
        _log.LogInformation("GetAllQuestions");
        return JsonSerializer.Serialize(result);
    }
}
