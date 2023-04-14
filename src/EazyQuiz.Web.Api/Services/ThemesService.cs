using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Services;

public class ThemesService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ThemesService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ThemeResponse>> GetAll(CancellationToken token)
    {
        var a = await _context.Themes.ToListAsync(token);
        return a.Select(x => _mapper.Map<ThemeResponse>(x)).ToList();
    }

    public async Task AddTheme(string name, CancellationToken token)
    {
        var a = new Theme() { Name = name };
        _context.Add(a);
        await _context.SaveChangesAsync(token);
    }
}
