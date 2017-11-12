using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ClanPenguin.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace ClanPenguin
{
    public class Startup
    {
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }
        private static IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClanPenguinContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ClanPenguinContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc(routes => routes.MapRoute(
                "Main",                                            
                "{action}/{user}",
                new { controller = "Home", action="Index", user=""}));
            app.UseMvcWithDefaultRoute();
        }
    }
}
