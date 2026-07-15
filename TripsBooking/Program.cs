using Microsoft.EntityFrameworkCore;
using TripsBooking.Database;
using TripsBooking.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TripsBooking.Repositories.Menha;
using TripsBooking.Repositories.User;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Services
// =====================

// login
builder.Services.AddScoped<IAuthService, AuthService>();

// Controllers
builder.Services.AddControllers();

// =====================
// Swagger
// =====================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TripsBooking API",
        Version = "v1"
    });

    // 👇 إضافة JWT Authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token like this: Bearer your_token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

// =====================
// Database Context
// =====================
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(
    builder.Configuration.GetConnectionString("DBConnection")
    )
);

//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DBConnection"))
//);

// =====================
// Repository
// =====================
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

// =====================
// Dependency Injection
// =====================
builder.Services.AddScoped<ISalaryService, SalaryService>();

// menha
// =====================
builder.Services.AddScoped<IMenhaRepository, MenhaRepository>();
builder.Services.AddScoped<MenhaService>();
// =====================
// CORS Policy
// =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
 policy.WithOrigins(
    "http://localhost:3001",
    "http://localhost:3000",
    "http://172.18.4.4:3000",
    "https://trips-booking-frontend.vercel.app",
    "https://trips-booking-frontend-i78c-psgnzjm4a-hisham1255s-projects.vercel.app"
)
          .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// =====================
// JWT Authentication
// =====================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.MapInboundClaims = false;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});


// builder.WebHost.UseUrls("http://0.0.0.0:5277");

var app = builder.Build();

// =====================
// Swagger
// =====================
   app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripsBooking API");
        c.RoutePrefix = "";
    });


// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
