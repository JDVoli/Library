using Library.Entities;
using Library.Repositories;
using Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

                    // Set the comments path for the Swagger JSON and UI.
                    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //c.IncludeXmlComments(xmlPath);
                }
            );
        }
    }
}
