
using Hotel_Management_System.Data;

using Hotel_Management_System.Data.Entities;

using Hotel_Management_System.Helpers;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;



namespace Hotel_Management_System

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);



            // MVC

            builder.Services.AddControllersWithViews();



            // Entity Framework Core + SQL Server

            builder.Services.AddDbContext<DataContext>(options =>

                options.UseSqlServer(

                    builder.Configuration.GetConnectionString("DefaultConnection")));



            // ASP.NET Core Identity

            builder.Services.AddIdentity<User, IdentityRole>(options =>

            {

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;



                options.Password.RequiredLength = 6;

                options.Password.RequireDigit = false;

                options.Password.RequireUppercase = false;

                options.Password.RequireLowercase = false;

                options.Password.RequireNonAlphanumeric = false;

            })

            .AddEntityFrameworkStores<DataContext>()

            .AddDefaultTokenProviders();



            // Repositories and helpers

            builder.Services.AddScoped<IHospedeRepository, HospedeRepository>();

            builder.Services.AddScoped<IUserHelper, UserHelper>();



            var app = builder.Build();



            // HTTP request pipeline

            if (!app.Environment.IsDevelopment())

            {

                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();

            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();



            app.UseRouting();



            // Authentication must come before authorization

            app.UseAuthentication();

            app.UseAuthorization();



            app.MapControllerRoute(

                name: "default",

                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();

        }

    }

}

