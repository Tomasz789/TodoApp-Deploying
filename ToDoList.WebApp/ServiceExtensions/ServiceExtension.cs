using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Entities;
using TodoApp.CurrencyHelper.Services;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.Wrappers;
using TodoApp.Repositories.Repositories;


namespace ToDoList.WebApp.ServiceExtension
{
    /// <summary>
    /// Extensions for ServiceCollection - contains methods for sql connection configuration
    /// also adds new services and configures identity for User.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Configures sql conection for db context.
        /// </summary>
        /// <param name="services">Extension for IServiceCollection.</param>
        /// <param name="config">App configurations.</param>
        public static void ConfigureSqlServerConnection(this IServiceCollection services, IConfiguration config)
        {
            var connString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<AppDatabaseContext>(opt => opt.UseSqlServer(connString, a => a.MigrationsAssembly("ToDoList.WebApp")));
        }

        /// <summary>
        /// Add service for repository wrapper which contains other repositories as properties.
        /// </summary>
        /// <param name="services">Extension for IServiceCollection.</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /// <summary>
        /// Configures identity for db context.
        /// </summary>
        /// <param name="services">Extension for IServiceCollection.</param>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<AppDatabaseContext>();
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.IdleTimeout = System.TimeSpan.FromMinutes(15);
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
        }

        public static void ConfigureExternServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyExchangeService, CurrencyExchangeService>();
        }
    }
}
