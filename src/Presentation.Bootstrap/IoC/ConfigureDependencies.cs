using Application.DTO;
using Application.Services;
using Data.Gateway;
using Domain.Core.Gateways;
using Domain.Core.Infrastruture;
using Domain.Core.Services;
using Infrastructure.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Bootstrap.IoC
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddSingleton<IHttpClientConnection>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                var wizardWorldServiceApiUrl = configuration?.GetSection("Dependencies:WizardWorldServiceConfiguration:WizardWorldServiceApiUrl")?.Value;
                var apiName = configuration?.GetSection("Service:Name")?.Value;
                var version = configuration?.GetSection("Service:Version")?.Value;

                var userAgent = $"{apiName}/{version}";

                HttpClient client = new();
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                return new HttpClientConnection(client, new Uri(wizardWorldServiceApiUrl));
            });

            return services;
        }

        public static IServiceCollection ConfigureWizardWorldGateway(this IServiceCollection services)
        {
            services.AddSingleton<IWizardWorldGateway>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var defaultTimeoutInMilliseconds = configuration?.GetSection("Dependencies:WizardWorldServiceConfiguration:DefaultTimeoutInMilliseconds")?.Value;
                return new WizardWorldGateway(serviceProvider.GetService<IHttpClientConnection>(), Convert.ToInt32(defaultTimeoutInMilliseconds));
            });

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IReadByService<ElixirReponse>, ElixirService>();
            services.AddSingleton<IReadService<IngredientReponse>, IngredientService>();

            return services;
        }
    }
}
