using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Common.ApplicationInsights.Configuration;
using PersonalFinance.Common.ApplicationInsights.Dtos;
using PersonalFinance.Common.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Common.ApplicationInsights.ServiceCollections
{
    public static class Extensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddApplicationInsightsServiceCollection(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var options = configuration.GetOptions<AppSettingInfo>(CommonConfiguration.AppInsName);

            if (options.Enabled && !string.IsNullOrEmpty(options.InstrumentationKey))
            {
                services.AddApplicationInsightsTelemetry(options.InstrumentationKey);
            }

            return services;
        }
    }
}
