
using Blink.Development.Authentication.Configuration;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
namespace Blink.Development.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
            //builder.Services.AddSingleton(sp =>
            //    sp.GetRequiredService<IOptions<JwtConfig>>().Value); 

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secret = builder.Configuration.GetSection("JwtConfig:Secret").Value;
                if (string.IsNullOrEmpty(secret))
                {
                    throw new InvalidOperationException("JWT Secret is not configured.");
                }
                var key = Encoding.ASCII.GetBytes(secret);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // change it when you deploy to production
                    ValidateAudience = false, // change it when you deploy to production
                    ValidateLifetime = true,//
                    RequireExpirationTime = false, // change it when you deploy to production needs to be updated when refresh token is implemented
                    ValidateIssuerSigningKey = true, //
                    IssuerSigningKey = new SymmetricSecurityKey(key) //
                };
            });

            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.SignIn.RequireConfirmedPhoneNumber = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Blink.Development.Api", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                        new string[] { }
                    }
                });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

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
        }
    }
}
