using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Areas.Admin.Data;
using WebApp.Models;
using Newtonsoft.Json;
namespace WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
             .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<DPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<CustomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).
               AddEntityFrameworkStores<DPContext>().AddDefaultUI().AddDefaultTokenProviders();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(5000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSession(options =>
            {
                options.Cookie.Name = "Cart";
                options.IdleTimeout = new TimeSpan(0, 30, 0);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Bills}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                 name: "Admin",
                pattern: "{area:exists}/{controller=Slides}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Categories}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "Admin",
                   pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "User",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "User",
                    pattern: "{area:exists}/{controller=ProductTypes}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                name: "User",
                pattern: "{area:exists}/{controller=Cart}/{action=Index}/{id?}");
            });
        }
    }
}
