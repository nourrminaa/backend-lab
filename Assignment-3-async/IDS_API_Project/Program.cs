using DotNetEnv;
using IDS_API_Project.Repositories;
using IDS_API_Project.Services;

// When we start the project, the computer reads this file first to set
// up the web server, load the environment variables, and launch the API.

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Read the values from the .env file
var server = Environment.GetEnvironmentVariable("DB_SERVER");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server={server};" + $"Database={database};" + $"User Id={user};" + $"Password={password};" + $"TrustServerCertificate=True;";
builder.Configuration["ConnectionStrings:Default"] = connectionString;


// Services:
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<DataRepository>();
builder.Services.AddScoped<IDataRepository, CachedDataRepository>();
builder.Services.AddScoped<IDataService, DataService>();


// Build the app:
var app = builder.Build();


// Middleware:
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
