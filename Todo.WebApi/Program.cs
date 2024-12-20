using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository;
using Repository.Context;
using Service;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantı dizesini ayarlayın
builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity yapılandırmasını ekleyin
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BaseDbContext>()
    .AddDefaultTokenProviders();

// Diğer servis bağımlılıklarını ekleyin
builder.Services.AddRepositoryDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();

// Global Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// JWT Authentication yapılandırması
var tokenOption = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();
if (tokenOption == null)
{
    throw new InvalidOperationException("TokenOption is not configured in appsettings.json");
}

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience[0],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey)
    };
});

// Swagger/OpenAPI yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kontrolcüler için ekleme
builder.Services.AddControllers();

var app = builder.Build();

// HTTP istek boru hattını yapılandırın
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication middleware'ini ekleyin
app.UseAuthorization();

app.MapControllers();

app.Run();
