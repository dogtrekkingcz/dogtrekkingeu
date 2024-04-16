using API.WebApiService.Entities;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Activities;

public sealed class CreateUserProfileHandler : IRequestHandler<CreateUserProfileRequest, CreateUserProfileResponse>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CreateUserProfileHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async ValueTask<CreateUserProfileResponse> Handle(CreateUserProfileRequest request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var userProfileService = scope.ServiceProvider.GetRequiredService<IUserProfileService>();

            var createUserProfileRequest =
                mapper.Map<PetsOnTrail.Interfaces.Actions.Entities.UserProfile.CreateUserProfileRequest>(request);

            var newEntry = await userProfileService.CreateUserProfileAsync(createUserProfileRequest, cancellationToken);

            var entry = mapper.Map<CreateUserProfileResponse>(newEntry);
            
            return new ValueTask<CreateUserProfileResponse>(entry).Result;
        }
    }
}
