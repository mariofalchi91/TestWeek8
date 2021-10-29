using Core;
using Core.Interfaces;
using EntityFramework;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsercitazioneMvc
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

            // dependency injections
            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IRepositoryMenu, RepositoryMenuEF>();
            services.AddTransient<IRepositoryPiatto, RepositoryPiattoEF>();
            services.AddTransient<IRepositoryUser, RepositoryUserEF>();

            services.AddDbContext<MenuContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("MioRistoranteDb"));
            });

            // filtro autenticazione

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op =>
                {
                    op.LoginPath = new PathString("/User/Login");
                    op.AccessDeniedPath = new PathString("/User/Forbidden");
                }
            );

            // filtro autorizzazione

            services.AddAuthorization(op =>
                {
                    op.AddPolicy("AdministratorUser", policy => policy.RequireRole("Administrator"));
                    op.AddPolicy("SimpleUser", policy => policy.RequireRole("User"));
                }
            );
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{code?}");
            });
        }
    }
}
