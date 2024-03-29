using Lap3_2.Controllers;
using Lap3_2.Models;
using Lap3_2.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lap3_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDeptRepo, DepartmentRepo>();
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();
            builder.Services.AddTransient<ICourseRepo, CourseRepo>();
            builder.Services.AddTransient<IUserRepo,UserRepo>();
            builder.Services.AddDbContext<ITIContext>(a =>
            a.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
            );
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
