using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using E_Learning.Repositories.Repository;

using E_Learning.Services.IService;
using E_Learning.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using E_Learning.Areas.Home.Data;

namespace E_Learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider().AddRazorRuntimeCompilation();
            // Customer Services
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
            });

            builder.Services.AddSingleton<IEmailSender>(new EmailService());


            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICourseRepository,CourseRepository>();
            builder.Services.AddScoped<ICourseCardService, CourseCardService>();
           


            builder.Services.AddIdentity<User, IdentityRole>(op =>
            {
                op.Password.RequireDigit = true;
                op.Password.RequiredLength = 8;
                op.Password.RequireUppercase = true;
                op.Password.RequireLowercase = true;
                op.Password.RequireNonAlphanumeric = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddSession(op =>
            {
                op.IOTimeout = TimeSpan.FromMinutes(5);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.MapControllerRoute(
                  name: "area",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
