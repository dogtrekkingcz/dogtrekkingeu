using System.IdentityModel.Tokens.Jwt;
using PetsOnTrail.Interfaces.Actions.Services;
using Microsoft.Extensions.Logging;

namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public class JwtTokenService : IJwtTokenService
{
    private string _userId = "";
    private readonly ILogger _logger;
    private readonly ICurrentUserIdService _currentUserIdService;

    public JwtTokenService(ILogger<JwtTokenService> logger, ICurrentUserIdService currentUserIdService)
    {
        _logger = logger;
        _currentUserIdService = currentUserIdService;
    }

    public void Parse(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (token is null)
            return;

        var pos = token.IndexOf("Bearer ");
        if (pos < 0)
        {
            _logger.LogInformation($"{nameof(Parse)}: Token is not a Bearer token");
            return;
        }

        token = token.Substring(pos + 7);
        _logger.LogInformation($"Token: '{token}'");

        if (handler.CanReadToken(token))
        {
            _logger.LogInformation("Ok, can read token ...");

            var jsonToken = handler.ReadToken(token);
            if (jsonToken != null)
            { 
                var securityToken = jsonToken as JwtSecurityToken;
                _userId = securityToken?.Claims?.FirstOrDefault(c => c.Type == "sub")?.Value ?? "";
                _currentUserIdService.SetUserId(_userId);

                _logger.LogInformation($"{securityToken?.Claims}");
            }
        }

        _logger.LogInformation($"'{nameof(Parse)}': userId: '{_userId}'");
    }

    public string GetUserId()
    {
        return _userId;
    }
}
