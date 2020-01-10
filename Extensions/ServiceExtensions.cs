using System;
using System.Text;
using Library.Entities;
using Library.Repositories;
using Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace Library.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(conf.GetConnectionString("LibraryDbConnectionString"));
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration conf)
        {
            services.AddSingleton(conf);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBookBorrowRepository, BookBorrowRepository>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration conf)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true, //TODO HAVE TO BE CHANGED IN PRODUCTION
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = "library.com",
                        ValidAudience = "library.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["SecretKey"]))
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition("oauth2", new ApiKeyScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                        In = "header",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                    c.OperationFilter<SecurityRequirementsOperationFilter>();
                    c.SwaggerDoc("v1", new Info { Title = "Library API", Version = "v1" });
                }
            );
        }
    }
}
