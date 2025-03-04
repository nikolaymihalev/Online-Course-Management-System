﻿using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Services;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentCourseService, StudentCourseService>();

            return services;
        }
    }
}
