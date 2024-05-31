using PetsOnTrail.Actions.Services.ActionsManage;
using PetsOnTrail.Actions.Services.Activities;
using PetsOnTrail.Actions.Services.Authorization;
using PetsOnTrail.Actions.Services.Checkpoints;
using PetsOnTrail.Actions.Services.CurrentUserId;
using PetsOnTrail.Actions.Services.EntriesManage;
using PetsOnTrail.Actions.Services.LiveUpdateSubscription;
using PetsOnTrail.Actions.Services.PetsManage;
using PetsOnTrail.Actions.Services.ResultsManage;
using PetsOnTrail.Actions.Services.Rights;
using PetsOnTrail.Actions.Services.UserProfileManage;
using Mails;
using Mails.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Api
{
    public static class DIComposer
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrail.Actions.Options.PetsOnTrailOptions options)
        {
            services
                .AddActions(typeAdapterConfig, options)
                .AddEntries(typeAdapterConfig, options)
                .AddRights(typeAdapterConfig)
                .AddUserProfiles(typeAdapterConfig, options)
                .AddPets(typeAdapterConfig, options)
                .AddResults(typeAdapterConfig, options)
                .AddEmails(typeAdapterConfig, new PetsOnTrailOptions { MongoDbConnectionString = options.MongoDbConnectionString })
                .AddCurrentUserId(typeAdapterConfig, options)
                .AddLiveUpdatesSubscription(typeAdapterConfig, options)
                .AddCheckpoints(typeAdapterConfig, options)
                .AddActivities(typeAdapterConfig, options)
                .AddJwtToken(typeAdapterConfig, options)
                .AddPetTypes(typeAdapterConfig, options);

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            
            return services;
        }
    }
}
