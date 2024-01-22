using FoxBnB.Controllers.Services;
using FoxBnB.Data;
using FoxBnB.TokenService;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.ProgramCsExtension
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
              IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                opt.EnableSensitiveDataLogging();
            });

            services.AddScoped<ITokenService, TokenServices>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddSignalR();

            services.AddCors();


            return services;
        }
    }
}
