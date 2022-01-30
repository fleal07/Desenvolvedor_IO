using AspNetCoreIdentity.Areas.Identity.Data;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));

                options.AddPolicy("Ler", policy => policy.Requirements.Add(new PermissaoNecessaria("Ler")));
                options.AddPolicy("Editar", policy => policy.Requirements.Add(new PermissaoNecessaria("Editar")));
            });

            return services;
        }

        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<AspNetCoreIdentityContext>();

            return services;
        }


    }
}
