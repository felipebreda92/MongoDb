using Api.MongoDb.Models;
using Api.MongoDb.Services;
using Api.MongoDb.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.MongoDb.Configurations
{
    public static class MongoConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration )
        {
            services.Configure<BookstoreDatabaseSettings>(
                        configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                                        sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<IBookService, BookService>();

            return services;
        }
    }
}
