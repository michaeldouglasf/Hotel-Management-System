
using Hotel_Management_System.Data;

using Microsoft.EntityFrameworkCore;



namespace Hotel_Management_System

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.

            builder.Services.AddControllersWithViews();



            // Entity Framework Core

            builder.Services.AddDbContext<DataContext>(options =>

                options.UseSqlServer(

                    builder.Configuration.GetConnectionString("DefaultConnection")));



            // Repositories

            builder.Services.AddScoped<IHospedeRepository, HospedeRepository>();



            var app = builder.Build();



            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())

            {

                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();

            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();



            app.UseRouting();



            app.UseAuthorization();



            app.MapControllerRoute(

                name: "default",

                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();

        }

    }

}

