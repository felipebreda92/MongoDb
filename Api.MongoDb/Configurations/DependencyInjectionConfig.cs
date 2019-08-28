using Api.MongoDb.Interfaces;
using Api.MongoDb.Models;
using Api.MongoDb.Notificacoes;
using Api.MongoDb.Services;
using Api.MongoDb.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.MongoDb.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                                        sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<IService, BookService>();
            services.AddScoped<INotificador, Notificador>();


            return services;
        }
    }
}
