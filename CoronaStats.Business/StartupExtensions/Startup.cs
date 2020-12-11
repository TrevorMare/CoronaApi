using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoronaStats.Business.StartupExtensions
{

    public static class Startup
    {

        public static IServiceCollection UseCoronaStatsBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<Interfaces.IRapidApiCovidApi, RapidApiCovidApi>();
            return services;
        }


    }


}