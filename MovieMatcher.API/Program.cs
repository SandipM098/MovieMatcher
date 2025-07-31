using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieMatcher.Application.Interfaces;
using MovieMatcher.Application.Services;
using MovieMatcher.Infrastructure;
using MovieMatcher.Shared;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database"))
);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<JwtSettings>>().Value);

// 2. Register Application Services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();


// 3. Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// 4. Add MVC Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
