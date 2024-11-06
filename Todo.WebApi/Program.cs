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

// Veritaban� ba�lant� dizesini ayarlay�n
builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity yap�land�rmas�n� ekleyin
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BaseDbContext>()
    .AddDefaultTokenProviders();

// Di�er servis ba��ml�l�klar�n� ekleyin
builder.Services.AddRepositoryDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();

// Global Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// JWT Authentication yap�land�rmas�
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

// Swagger/OpenAPI yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kontrolc�ler i�in ekleme
builder.Services.AddControllers();

var app = builder.Build();

// HTTP istek boru hatt�n� yap�land�r�n
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
