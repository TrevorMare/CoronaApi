using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace CoronaStats.Business.StartupExtensions
{

    public static class Startup
    {

        public static IServiceCollection UseCoronaStatsBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            
            var rapidApiConfig = LoadRapidApiConfiguration(configuration);

            // Configure the http client with the default parameters as well as the retry policy (Polly)
            services.AddHttpClient(Common.Constants.RapidApiFactoryClientName, c =>
            {
                c.BaseAddress = new Uri(rapidApiConfig.Endpoint);
                // Github API versioning
                c.DefaultRequestHeaders.Add("x-rapidapi-key", rapidApiConfig.Key);
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("x-rapidapi-host", rapidApiConfig.Host);
                
            })
            .AddPolicyHandler(LoadHttpClientRetryPolicy());

            services.Configure<CoronaStats.Core.Config.RapidApiConfig>(configuration.GetSection("RapidApiConfig"));
            services.AddScoped<Interfaces.IRapidApiCovidStatistics, RapidApiCovidStatistics>();

            return services;
        }


        #region Private Methods
        private static IAsyncPolicy<HttpResponseMessage> LoadHttpClientRetryPolicy()
        {
            return HttpPolicyExtensions
                // Handle HttpRequestExceptions, 408 and 5xx status codes
                .HandleTransientHttpError()
                // Handle 404 not found
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                // Handle 401 Unauthorized
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                // What to do if any of the above erros occur:
                // Retry 3 times, each time wait 1,2 and 4 seconds before retrying.
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        

        /// <summary>
        /// Loads the rapid api configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static Core.Config.RapidApiConfig LoadRapidApiConfiguration(IConfiguration configuration)
        {
            Core.Config.RapidApiConfig rapidApiConfig = new Core.Config.RapidApiConfig();
            configuration.Bind("RapidApiConfig", rapidApiConfig);

            // Validate the configuration object
            if (rapidApiConfig == null)
            {
                throw new Exception("Rapid Api Configuration could not be loaded");
            }

            if (string.IsNullOrWhiteSpace(rapidApiConfig.Endpoint))
            {
                throw new Exception("Rapid Api Endpoint is required");
            }

            if (string.IsNullOrWhiteSpace(rapidApiConfig.Host))
            {
                throw new Exception("Rapid Api Host is required");
            }

            if (string.IsNullOrWhiteSpace(rapidApiConfig.Key))
            {
                throw new Exception("Rapid Api Key is required");
            }

            return rapidApiConfig;
        }

        #endregion

    }


}