using DogtrekkingCzWebApiService.Entities;
using Mediator;

namespace DogtrekkingCzWebApiService.Validators
{
    public static class DIComposerValidators
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<IPipelineBehavior<ActionDetailRequest, ActionDetailResponse>, ActionDetailValidator>();

            return services;
        }
    }
}
