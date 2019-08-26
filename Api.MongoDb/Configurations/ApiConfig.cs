using Api.MongoDb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MongoDb.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BookstoreDatabaseSettings>(
                        configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            return services;
        }
    }
}
