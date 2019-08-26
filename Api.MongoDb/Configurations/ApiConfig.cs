using Api.MongoDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
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

            services.AddMvc()
                .AddJsonOptions(options => options.UseMemberCasing())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }
    }
}
