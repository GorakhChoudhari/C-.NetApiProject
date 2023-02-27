using KE.Repository.Implementation;
using KE.Repository.Infrastructure;
using KE.Repository.Infrastructure.Interface;
using KE.Repository.Interface;
using KE.Services.Implementation;
using KE.Services.Interface;
using KTS.FrameworkExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KE.DependencyInjection
{
    public static class ServiceRegestration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployee, EmployeeRepository>();
        }
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSettingsProvider(configuration);
            services.AddTransient<IQueryBuilder, SqlQueryBuilder>();
            /* services.AddTransient<ISettingsService, SettingsService>();*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IConnectionFactory, SqlConnectionFactory>();
        }
    }
}