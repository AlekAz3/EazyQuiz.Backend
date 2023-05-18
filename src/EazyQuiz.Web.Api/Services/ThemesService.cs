using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

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
        var themes = await _context.Themes
            .AsNoTracking()
            .ToListAsync(token);
        return themes.Select(_mapper.Map<ThemeResponse>).ToList();
    }

    /// <summary>
    /// Добавить тему
    /// </summary>
    /// <param name="name">Название темы</param>
    /// <param name="token">Токен отмены вопроса</param>
    public async Task AddTheme(string name, CancellationToken token)
    {
        var theme = new Theme() { Name = name };
        _context.Add(theme);
        await _context.SaveChangesAsync(token);
    }
}
