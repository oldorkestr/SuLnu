using SuLnu.DAL.EF;
using SuLnu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SuLnu.BLL.Infrastructure.MapperProfiles;

namespace SuLnu.BLL.Infrastructure
{
    public static class IServiceCollectionDIExtension
    {
        public static void AddDALDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SuLnuDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SuLnuDbContext>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new NewsProfile());
                mc.AddProfile(new FacultyProfile());

            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}