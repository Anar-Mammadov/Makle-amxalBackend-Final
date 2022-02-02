using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity.Membership;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI
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
            services.AddControllersWithViews(cfg =>
            {

                var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));

            });

            services.AddDbContext<MaklerSamxalDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("cString"));
            });

            //Membership ucun yazilib.
            services.AddIdentity<MaklerUser, MaklerRole>()
                .AddEntityFrameworkStores<MaklerSamxalDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {

                cfg.Password.RequireDigit = false; //Reqem teleb elesin?
                cfg.Password.RequireUppercase = false; //Boyuk reqem teleb elesin?
                cfg.Password.RequireLowercase = false; //Kick reqem teleb elesin?
                cfg.Password.RequiredUniqueChars = 1; //Tekrarlanmiyan nece  sombol olsun?(11-22-3)
                cfg.Password.RequireNonAlphanumeric = false; // 0-9 a-z A-Z  Olmayanlari teleb elemesin?
                cfg.Password.RequiredLength = 3; //Password nece simboldan ibaret olsun?

                cfg.User.RequireUniqueEmail = true; //Email tekrarlanmasin 1 adam ucun?
                //cfg.User.AllowedUserNameCharacters = ""; //User neleri isdifade eliye biler?

                cfg.Lockout.MaxFailedAccessAttempts = 3;// 3 seferden cox sefh giris etse diyansin?
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 2, 0);//Nece deq gozlesin ?


            });


            services.ConfigureApplicationCookie(cfg =>
            {

                cfg.LoginPath = "/signin.html"; //Eger adam login olunmuyubsa hara gondersin?

                cfg.AccessDeniedPath = "/accessdenied.html";//Senin icazen var bu linke yeni link atanda gire bilmesin diye (yeni fb nese atanda ve ya tiktokda olanda beyenmek olmur zad)

                cfg.ExpireTimeSpan = new TimeSpan(0, 10, 10);//Seni sayitda nece deq saxlasin eger sen hecne elemirsense atacaq yeni login olduqdan sonra diansan ve ya saty girdikden sonra diansan

                cfg.Cookie.Name = "riode"; //Cookie adi ne olsun isdediyin adi yaza bilersen;

            });


            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<UserManager<MaklerUser>>();
            services.AddScoped<SignInManager<MaklerUser>>();

            services.AddMediatR(this.GetType().Assembly);
            //Mediatr Commanlarda Create olunanda isvalid yazmaq ucun yazilib                
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
          // app.SeedMembership();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("riode")
                && context.Request.RouteValues.TryGetValue("area", out object areaName)
                && areaName.ToString().ToLower().Equals("admin"))
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    if (attr == null)
                    {

                        context.Response.Redirect("/admin/singin.html");
                        await context.Response.CompleteAsync();

                    }

                }
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                   name: "Default-signin",
                   pattern: "accessdenied.html",
                   defaults: new
                   {
                       areas = "",
                       controller = "Home",
                       action = "accessdenied"
                   });

                endpoints.MapControllerRoute("adminsingin", "admin/singin.html",
                defaults: new
                {
                    controller = "Account",
                    action = "singin",
                    area = "Admin"
                });



                endpoints.MapControllerRoute(

                    name: "Default-signin",
                    pattern: "signin.html",
                    defaults: new
                    {
                        areas = "",
                        controller = "Home",
                        action = "signin"
                    });


                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
