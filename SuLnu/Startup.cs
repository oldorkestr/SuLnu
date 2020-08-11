using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SuLnu.DAL.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuLnu.BLL.Configs;
using Microsoft.Extensions.Options;
using SuLnu.DAL.Entities;
using AutoMapper;
using SuLnu.BLL.Infrastructure;
using SuLnu.BLL.Interfaces;
using SuLnu.BLL.Services;

namespace SuLnu
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
            services.Configure<AdminConfig>(Configuration.GetSection("AdminConfig"));

            services.AddDbContext<SuLnuDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SuLnuDBConnection")));

            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            })            
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SuLnuDbContext>();

           
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISignInService, SignInService>();

            services.AddAutoMapper();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateUserRoles(serviceProvider).Wait();
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in new string[] { "ActiveMember", "FacultyMember", "FacultySecretary", "AlternateFacultyAdmin", "FacultyAdmin", "Secretary", "AlternateAdmin", "Admin" })
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var adminConfig = serviceProvider.GetRequiredService<IOptions<AdminConfig>>();

            if (await userManager.FindByEmailAsync(adminConfig.Value.Email) == null)
            {
                var admin = new AppUser
                {
                    UserName = adminConfig.Value.Email,
                    Email = adminConfig.Value.Email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, adminConfig.Value.Password);
                await userManager.AddToRolesAsync(admin, new string[] { "ActiveMember", "FacultyMember", "FacultySecretary", "AlternateFacultyAdmin", "FacultyAdmin", "Secretary", "AlternateAdmin", "Admin" });
            }
        }
    }
}
