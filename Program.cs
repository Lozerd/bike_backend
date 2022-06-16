using bike_backend.Databases;
using bike_backend.Databases.Repositories;
using bike_backend.Handlers;
using bike_backend.Interfaces;
using bike_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ITokenService, TokenService>();

// Swagger
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();

    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Bike Api",
        Version = "v1",
        Description = "Bearer " + builder.Configuration.GetSection("Secret").Value
    });

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        In = ParameterLocation.Header,
        Description = "Bearer " + builder.Configuration.GetSection("Secret").Value
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearer"
                }
            },
            new string[] { }
        }
    });
});

// Bearer Authentication for frontend
builder.Services.AddAuthentication("BearerAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BearerAuthenticationHandler>("BearerAuthentication", null);

// Database Connection

// ConnectionString
string connectionString = builder.Configuration.GetConnectionString("MySqlContext");

// MySqlVersion
ServerVersion mySqlServerVersion = ServerVersion.AutoDetect(connectionString);

// // Bike context
builder.Services.AddDbContext<MySqlDbContext>(options =>
{
    options
        .UseMySql(connectionString, mySqlServerVersion)
        .LogTo(Console.WriteLine, LogLevel.Debug)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});


// Bike Repository
builder.Services.AddScoped<IBikeRepository, BikeRepository>();

builder.Services.AddControllers();
builder.Services.AddRouting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();