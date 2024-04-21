
using ManageSD_WebApi.Interfaces;
using ManageSD_WebApi.Models;
using ManageSD_WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ManageSD_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SdContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("c3"));
            });




            //custom service for interfaces and repos
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
