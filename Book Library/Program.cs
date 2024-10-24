using Microsoft.EntityFrameworkCore;
using Book_Library.Data;
using Book_Library.Repositories.Services;
using Book_Library.Repositories.Interfaces;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

namespace Book_Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Connection string for the database
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                       ?? "Data Source=BookLibrary.db";

            // Register DbContext with SQLite
            builder.Services.AddDbContext<LibraryContext>(opt => opt.UseSqlite(connectionString));

            // Register repositories
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            // Register controllers
            builder.Services.AddControllers();

            // Swagger configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Book Library API",
                    Version = "v1",
                    Description = "API for managing books in the Book Library"
                });
            });

            var app = builder.Build();

            // Enable Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Library API v1");
                options.RoutePrefix = string.Empty; // Serve Swagger at the root URL
            });

            // Automatically open Swagger in the default browser
            OpenBrowser("http://localhost:5000"); // Change port if needed
            app.UseHttpsRedirection();

            // Helper function to open the browser
            static void OpenBrowser(string url)
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to open browser: {ex.Message}");
                }
            }

            // Configure routing and endpoints
            app.UseRouting();
            app.UseAuthorization();

            // Map controllers
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
