using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AspNetCoreIdentity.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage razor, string clainName, string clainValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(razor.Context, clainName, clainValue);
        }

        public static string IfClaimShow(this RazorPage razor, string clainName, string clainValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(razor.Context, clainName, clainValue) ? "" : "disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context, string clainName, string clainValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(context, clainName, clainValue) ? page : null;
        }
    }
}
