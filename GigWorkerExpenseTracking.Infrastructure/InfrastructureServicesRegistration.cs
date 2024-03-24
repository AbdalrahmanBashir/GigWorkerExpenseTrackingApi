using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Infrastructure.Repositories;
using GigWorkerExpenseTracking.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GigWorkerExpenseTracking.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("dbConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString!,
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddTransient<IAuthenticationService, JwtAuthentication>();

            return services;
        }
    }
}
