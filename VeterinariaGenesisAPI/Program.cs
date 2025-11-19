using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Helpers;
using VeterinariaGenesisAPI.Middleware;
using VeterinariaGenesisAPI.Services;
using VeterinariaGenesisAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer not configured");
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience not configured");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
    options.AddPolicy("Veterinario", policy => policy.RequireRole("Veterinario"));
    options.AddPolicy("Recepcionista", policy => policy.RequireRole("Recepcionista"));
    options.AddPolicy("AdministradorOrVeterinario", policy => policy.RequireRole("Administrador", "Veterinario"));
    options.AddPolicy("AllRoles", policy => policy.RequireRole("Administrador", "Veterinario", "Recepcionista"));
});

// Register Data Layer
builder.Services.AddScoped<ConexionDB>();

// Register Helpers
builder.Services.AddScoped<JwtHelper>();

// Register DAOs
builder.Services.AddScoped<IAuthDAO, AuthDAO>();
builder.Services.AddScoped<IPropietarioDAO, PropietarioDAO>();
builder.Services.AddScoped<IMascotaDAO, MascotaDAO>();
builder.Services.AddScoped<ICitaDAO, CitaDAO>();
builder.Services.AddScoped<IFacturaDAO, FacturaDAO>();
builder.Services.AddScoped<IReporteDAO, ReporteDAO>();
builder.Services.AddScoped<IVeterinarioDAO, VeterinarioDAO>();
builder.Services.AddScoped<IServicioDAO, ServicioDAO>();

// Register Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPropietarioService, PropietarioService>();
builder.Services.AddScoped<IMascotaService, MascotaService>();
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<IServicioService, ServicioService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Veterinaria Genesis API",
        Version = "v1",
        Description = "API RESTful de alto rendimiento para gestión de veterinaria usando ADO.NET"
    });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware pipeline (orden importante)
app.UseMiddleware<ExceptionMiddleware>(); // Debe ir primero para atrapar todas las excepciones
app.UseHttpsRedirection();
app.UseAuthentication(); // Debe ir antes de UseAuthorization
app.UseAuthorization();
app.MapControllers();

app.Run();
