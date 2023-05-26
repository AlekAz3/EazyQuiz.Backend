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
    /// Получить все активные темы
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем </returns>
    public async Task<IReadOnlyCollection<ThemeResponse>> GetAllActive(CancellationToken token)
    {
        var themes = await _context.Themes
            .AsNoTracking()
            .Where(x => x.Enabled)
            .OrderBy(x => x.Name)
            .ToListAsync(token);
        return themes.Select(_mapper.Map<ThemeResponse>).ToList();
    }

    /// <summary>
    /// Получить все темы
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем </returns>
    public async Task<IReadOnlyCollection<ThemeResponseWithFlag>> GetAll(CancellationToken token)
    {
        var themes = await _context.Themes
            .AsNoTracking()
            .ToListAsync(token);

        return themes.Select(_mapper.Map<ThemeResponseWithFlag>).ToList();
    }

    /// <summary>
    /// Обновить коллекцию тем
    /// </summary>
    /// <param name="themes"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task UpdateThemes(IReadOnlyCollection<ThemeResponseWithFlag> themes, CancellationToken token)
    {
        //var themesIds = themes.Select(x => x.Id).ToList();
        //var entityThemes = _context.Themes.Where(x => themesIds.Contains(x.Id));

        //_context.Themes.RemoveRange(entityThemes);
        //_context.Themes.AddRange(themes.Select(_mapper.Map<Theme>));
        //await _context.SaveChangesAsync(token);
        var entityThemes = themes.Select(_mapper.Map<Theme>);
        _context.Themes.UpdateRange(entityThemes);
        await _context.SaveChangesAsync(token);

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
