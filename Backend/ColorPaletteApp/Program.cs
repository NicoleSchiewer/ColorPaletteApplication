using ColorPaletteApp.Interfaces;
using ColorPaletteApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddScoped<IGeminiService, GeminiService>();
builder.Services.AddHttpClient();

builder.Services.AddControllers();

// Configure CORS to allow your frontend origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVercelFrontend", policy =>
    {
        policy.WithOrigins("https://color-palette-application.vercel.app")  // <-- no trailing slash
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// IMPORTANT: Add UseRouting BEFORE UseCors
app.UseRouting();

app.UseCors("AllowVercelFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
