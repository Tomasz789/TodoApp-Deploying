using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.WebApp.ServiceExtension;

namespace ToDoList.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.ConfigureSqlServerConnection(Configuration);
            services.ConfigureIdentity();
            services.ConfigureRepositoryWrapper();
            services.ConfigureSession();
            //services.ConfigureExternServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("list", "List", new {Controller = "List", action="Index"});
                endpoints.MapControllerRoute("task", "Task", new { Controller = "Task", action = "Index", id = 1});
                endpoints.MapControllerRoute("account", "Account", new { Controller = "Account", action = "Register"});
                endpoints.MapControllerRoute("page", "Page{page:int}", new { Controller = "List", action = " Index", page = 1 });
                endpoints.MapControllerRoute("pagination", "List/Page{page}", new {Controller = "List", action="Index", page=1});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
