using DogsOnTrail.Actions.Services.ActionsManage;
using DogsOnTrail.Actions.Services.CurrentUserId;
using DogsOnTrail.Actions.Services.DogsManage;
using DogsOnTrail.Actions.Services.EntriesManage;
using DogsOnTrail.Actions.Services.LiveUpdateSubscription;
using DogsOnTrail.Actions.Services.ResultsManage;
using DogsOnTrail.Actions.Services.Rights;
using DogsOnTrail.Actions.Services.UserProfileManage;
using Mails;
using Mails.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrail.Actions.Options.DogsOnTrailOptions options)
        {
            services
                .AddActions(typeAdapterConfig, options)
                .AddEntries(typeAdapterConfig, options)
                .AddRights(typeAdapterConfig)
                .AddUserProfiles(typeAdapterConfig, options)
                .AddDogs(typeAdapterConfig, options)
                .AddResults(typeAdapterConfig, options)
                .AddEmails(typeAdapterConfig, new DogsOnTrailOptions { MongoDbConnectionString = options.MongoDbConnectionString })
                .AddCurrentUserId(typeAdapterConfig, options)
                .AddLiveUpdatesSubscription(typeAdapterConfig, options);
            
            return services;
        }
    }
}
