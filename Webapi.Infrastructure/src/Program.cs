using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Webapi.Business.src.Abstractions;
using Webapi.Business.src.RepoImplementations;
using Webapi.Domain.src.RepoInterfaces;
// using Webapi.Infrastructure.src.Database;
// using Webapi.Infrastructure.src.RepoImplimetations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Webapi.Infrastructure.src;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();

// Register the database context for dependency injection
//builder.Services.AddDbContext<DatabaseContex>(options =>
    //options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

//add service for auto dependency injection
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Bearer token authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Config route (like lowercases etc.)
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});
//authentication:

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "prackey-backend",
        IssuerSigningKey = new JsonWebKey("prac-backend"),
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
