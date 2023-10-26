using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValdoBase.Database.Contexts;
using ValdoBase.Database.Seed;

namespace ValdoBase.IoC
{
    public static class DatabaseIoC
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            RegisterContext(services, config);
            RegisterSeeds(services);
        }

        internal static void Start(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<IValdoBaseContext>();
            if (!context.AllMigrationsApplied())
                context.Database.Migrate();

            serviceScope.ServiceProvider.GetService<ISeed>().Execute();
        }

        private static void RegisterContext(IServiceCollection services, IConfiguration config)
        {
            throw new NotImplementedException();
        }

        private static void RegisterSeeds(IServiceCollection services)
        {
            services.AddScoped<ISeed, Seed>();
        }
    }
}