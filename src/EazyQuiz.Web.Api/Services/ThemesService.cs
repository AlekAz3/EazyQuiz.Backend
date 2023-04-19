using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Services;

/// <summary>
/// Сервис работающий с темами
/// </summary>
public class ThemesService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public ThemesService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить все темы
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем </returns>
    public async Task<IReadOnlyCollection<ThemeResponse>> GetAll(CancellationToken token)
    {
        var a = await _context.Themes.ToListAsync(token);
        return a.Select(x => _mapper.Map<ThemeResponse>(x)).ToList();
    }

    /// <summary>
    /// Добавить тему
    /// </summary>
    /// <param name="name">Название темы</param>
    /// <param name="token">Токен отмены вопроса</param>
    public async Task AddTheme(string name, CancellationToken token)
    {
        var a = new Theme() { Name = name };
        _context.Add(a);
        await _context.SaveChangesAsync(token);
    }
}
