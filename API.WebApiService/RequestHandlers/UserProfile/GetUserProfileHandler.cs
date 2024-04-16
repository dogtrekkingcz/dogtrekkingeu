using API.WebApiService.Entities;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Activities;

public sealed class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, GetUserProfileResponse>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public GetUserProfileHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async ValueTask<GetUserProfileResponse> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var userProfileService = scope.ServiceProvider.GetRequiredService<IUserProfileService>();

            var getUserProfileRequest = 
                mapper.Map<PetsOnTrail.Interfaces.Actions.Entities.UserProfile.GetUserProfileRequest>(request);

            var newEntry = await userProfileService.GetUserProfileAsync(getUserProfileRequest, cancellationToken);

            var entry = mapper.Map<GetUserProfileResponse>(newEntry);
            
            return new ValueTask<GetUserProfileResponse>(entry).Result;
        }
    }
}
