using EazyQuiz.Models;
using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Controllers;
using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;

namespace EazyQuiz.Web.Api.Services;

public class UserAuthentication 
{
    private readonly DataContext _dataContext;
    private readonly ILogger<UserAuthentication> _log;
    private readonly IConfiguration _config;

    public UserAuthentication(DataContext dataContext, ILogger<UserAuthentication> logger, IConfiguration config)
    {
        _dataContext = dataContext;
        _log = logger;
        _config = config;
    }

}
