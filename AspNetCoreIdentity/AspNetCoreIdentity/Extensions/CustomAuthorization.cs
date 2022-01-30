using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Security.Claims;

namespace AspNetCoreIdentity.Extensions
{
    public class CustomAuthorization
    {
        //Método base para validar os tipos de claims
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string clainName, string clainValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(clainName, clainValue) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Outra forma de utilizar uma url de retorno para um httpcontext
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/Login", ReturnUrl = context.HttpContext.Request.Path.ToString() }));

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
                //context.Result = new ForbidResult();
                context.Result = new StatusCodeResult(403);
        }
    }
}
