using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            return services;
        }
    }
}
