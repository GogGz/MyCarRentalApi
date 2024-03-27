
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyCarRentalApi.DAL.Context;
using MyCarRentalApi.DAL.Repository;

namespace MyCarRentalApi
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
            builder.Services.AddSwaggerGen( c => {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "MyCarRentalAPI",
                    Version = "V1",
                    Description = "A Brief Description of My APIs",
                    Contact = new OpenApiContact
                    {
                        Name = "Support",
                        Email = "gohar_ghazaryan@outlook.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MyCarRentalAPI License",
                        Url = new Uri("https://www.enterprise.am/terms-and-conditions")
                    }
                });
            });

            builder.Services.AddDbContext<MyCarRentalApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/V1/swagger.json", "My API V1");
                });


            }
            //app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
