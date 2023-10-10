using GameDatabase.API.AuthEndpoints;
using GameDatabase.API.Extensions;
using GameDatabase.Infrastructure;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

IConfiguration configuration = configurationBuilder.Build();

builder.Services.AddControllers();

builder.Services.AddSingleton(configuration);

builder.Services.AddJWTAuthentication(configuration);

builder.Services.AddAutoMapper(typeof(AuthenticationMapper));
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
