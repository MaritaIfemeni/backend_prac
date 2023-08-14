using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Webapi.Infrastructure.src.Database;
using System.Text;
using Webapi.Infrastructure.src.RepoImplimetations;
using Webapi.Business.src.RepoImplementations;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Business.src.Abstractions;
using Webapi.Business.src.Shared;
using Webapi.Infrastructure.src.AuthorizationRequirement;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContex>();

// Add service DI
builder.Services
.AddScoped<IUserRepo, UserRepo>()
.AddScoped<IUserService, UserService>()
.AddScoped<IAuthService, AuthServices>()
.AddScoped<IProductRepo, ProductRepo>()
.AddScoped<IProductService, ProductServices>()
.AddScoped<IOrderRepo, OrderRepo>()
.AddScoped<IOrderService, OrderService>();

// Add services to the container.

builder.Services.AddControllers();

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

// add policy based requirement handler to service
builder.Services
.AddSingleton<OwnerOnlyRequirementHandler>();

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
        ValidIssuer = "prac-backend",
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("prackey-backend-jsdguyfsdgcjsdbchjsdb jdhscjysdcsdj")),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("OwnerOnly", policy => policy.Requirements.Add(new OwnerOnlyRequirement()));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Enable CORS with the default policy (allow any origin, method, and header)
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
