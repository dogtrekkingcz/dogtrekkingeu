using System.IdentityModel.Tokens.Jwt;
using PetsOnTrail.Interfaces.Actions.Services;
using Microsoft.Extensions.Logging;

namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public class JwtTokenService : IJwtTokenService
{
    private Guid _userId = Guid.Empty;
    private readonly ILogger _logger;
    private readonly ICurrentUserIdService _currentUserIdService;

    public JwtTokenService(ILogger<JwtTokenService> logger, ICurrentUserIdService currentUserIdService)
    {
        _logger = logger;
        _currentUserIdService = currentUserIdService;
    }

    public string Parse(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (token is null)
            return string.Empty;

        var pos = token.IndexOf("Bearer ");
        if (pos < 0)
        {
            _logger.LogInformation($"{nameof(Parse)}: Token is not a Bearer token");
            return string.Empty;
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
                var userId = securityToken?.Claims?.FirstOrDefault(c => c.Type == "sub")?.Value ?? Guid.Empty.ToString();
                _userId = Guid.Parse(userId);

                _currentUserIdService.SetUserId(_userId);

                _logger.LogInformation($"{securityToken?.Claims}");
            }
        }

        _logger.LogInformation($"'{nameof(Parse)}': userId: '{_userId}'");

        return _userId.ToString();
    }

    public Guid GetUserId()
    {
        return _userId;
    }
}
