﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using miniETicaret.Data;
using miniETicaret.Middleware;
using miniETicaret.Models.Entity;
using System;
using System.Globalization;

namespace miniETicaret
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Validasyon işlemleri için servis eklendi
            services.AddControllersWithViews()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            //DB bağlantısı için servis eklendi
            services.AddDbContext<eTicaretDBContext>(options =>
                options.UseSqlite("Data Source=eTicaret.db"));

            //Identity için servis eklendi
            services.AddIdentity<AppUser, AppRole>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;

                //options.Lockout.MaxFailedAccessAttempts = 3;  // 3 kere şifre yanlış girilirse blocklama yapar
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // 15 dakika boyunca yeni bir istek atılmaz ise kullanıcı logout olur
            })
                .AddEntityFrameworkStores<eTicaretDBContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //Erişim izni reddedildiğinde yönlendirilecek sayfa belirlendi
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Error/AccessDenied";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Kültür ayarlarını yapıldı decimal ifadelerde ondalıklı sayıyı almak için
            var supportedCultures = new[] { new CultureInfo("en-US") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<UserRoleMiddleware>(); //kullanıcı rollerini layouta almak için kullanılıyor
            app.UseStatusCodePagesWithReExecute("/Error/Status", "?code={0}");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
