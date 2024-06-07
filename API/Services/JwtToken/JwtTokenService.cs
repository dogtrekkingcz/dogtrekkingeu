using System.IdentityModel.Tokens.Jwt;
using PetsOnTrail.Interfaces.Actions.Services;
using Microsoft.Extensions.Logging;
using Storage.Interfaces;
using Storage.Entities.UserProfiles;

// list of the jwt claims: https://www.iana.org/assignments/jwt/jwt.xhtml

namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public class JwtTokenService : IJwtTokenService
{
    private Guid _userId = Guid.Empty;
    private GetUserProfileInternalStorageResponse _user = null;
    private readonly ILogger _logger;
    private readonly ICurrentUserIdService _currentUserIdService;
    private readonly IUserProfilesRepositoryService _userProfilesRepositoryService;

    public JwtTokenService(ILogger<JwtTokenService> logger, ICurrentUserIdService currentUserIdService, IUserProfilesRepositoryService userProfilesRepositoryService)
    {
        _logger = logger;
        _currentUserIdService = currentUserIdService;
        _userProfilesRepositoryService = userProfilesRepositoryService;
    }

    public async Task<string> Parse(string token, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();

        if (token is null)
            return string.Empty;

        var pos = token.IndexOf("Bearer ");
        if (pos < 0)
        {
            return string.Empty;
        }

        token = token.Substring(pos + 7);
        _logger.LogInformation($"Token: '{token}'");

        if (handler.CanReadToken(token))
        {   
            var jsonToken = handler.ReadToken(token);
            if (jsonToken != null)
            { 
                var securityToken = jsonToken as JwtSecurityToken;
                var userId = securityToken?.Claims?.FirstOrDefault(c => c.Type == "sub")?.Value ?? Guid.Empty.ToString();
                _userId = Guid.Parse(userId);

                _currentUserIdService.SetUserId(_userId);
            }
        }


        _logger.LogInformation($"'{nameof(Parse)}': userId: '{_userId}'");

        _user = await _userProfilesRepositoryService.GetUserProfileAsync(new Storage.Entities.UserProfiles.GetUserProfileInternalStorageRequest { UserId = _userId }, cancellationToken);
        if (_user == null)
        {
            var jsonToken = handler.ReadToken(token);
            var securityToken = jsonToken as JwtSecurityToken;

            await _userProfilesRepositoryService.AddUserProfileAsync(
                new Storage.Entities.UserProfiles.CreateUserProfileInternalStorageRequest 
                { 
                    UserId = _userId,
                    Roles = new List<string> { Constants.Roles.InternalUser.Id },
                    FirstName = securityToken?.Claims?.FirstOrDefault(c => c.Type == "given_name")?.Value ?? "",
                    LastName = securityToken?.Claims?.FirstOrDefault(c => c.Type == "family_name")?.Value ?? "",
                    Contact = new CreateUserProfileInternalStorageRequest.ContactDto
                    { 
                        EmailAddress = securityToken?.Claims?.FirstOrDefault(c => c.Type == "email")?.Value ?? "",
                        PhoneNumber = securityToken?.Claims?.FirstOrDefault(c => c.Type == "phone_number")?.Value ?? ""
                    }
                }, CancellationToken.None);

            _user = await _userProfilesRepositoryService.GetUserProfileAsync(new Storage.Entities.UserProfiles.GetUserProfileInternalStorageRequest { UserId = _userId }, cancellationToken);
        }

        _logger.LogInformation($"Logged user: ID: '{_user.Id}', FirstName: '{_user.FirstName}', LastName: '{_user.LastName}', Email: '{_user.Email}', Phone: '{_user.Contact.PhoneNumber}'");

        return _userId.ToString();
    }

    public Guid GetUserId()
    {
        return _userId;
    }
}
