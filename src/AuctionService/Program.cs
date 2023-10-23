// Create a new instance of a web application builder, using command line arguments (args).

using AuctionService.Data;
using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add controller services to the dependency injection container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AuctionDbContext>(opt =>
{
    // Configure the DbContext options for AuctionDbContext.
    
    // UseNpgsql is specifying the PostgreSQL database provider.
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
    // GetConnectionString retrieves the database connection string from the configuration.
});

//add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // look for profile class

builder.Services.AddEndpointsApiExplorer(); // Add API explorer services to the container.

// Build the web application based on the configured services.
var app = builder.Build();

// Configure the HTTP request pipeline.


// Enable authorization middleware, allowing for authentication and authorization checks.
app.UseAuthorization();

// Map controllers to their respective routes.
app.MapControllers();

try
{
    // Attempt to initialize the database using the Dbinitalizer.InitDB method.
    Dbinitalizer.InitDB(app);
}
catch (Exception e)
{
    // A catch block to handle any exceptions that may occur during database initialization.

    // Print information about the exception to the console. This helps with debugging and diagnosing issues.
    Console.WriteLine(e);
}


// Start the application, handling incoming HTTP requests.
app.Run();