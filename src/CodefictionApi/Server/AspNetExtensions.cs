using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.Owin;

namespace Codefiction.CodefictionTech.CodefictionApi.Server
{
    public static class AspNetExtensions
    {
        public static T GetFeature<T>(this NancyContext nancyContext)
        {
            var httpContext = nancyContext.GetHttpContext();
            return httpContext != null ? httpContext.Features.Get<T>() : default;
        }

        public static T GetRequiredService<T>(this NancyContext nancyContext)
        {
            var httpContext = nancyContext.GetHttpContext();
            return httpContext != null ? httpContext.RequestServices.GetRequiredService<T>() : default;
        }

        public static HttpContext GetHttpContext(this NancyContext context)
        {
            var owinEnvironment = context.GetOwinEnvironment();

            var httpContextKey = typeof(HttpContext).FullName;

            if (owinEnvironment.TryGetValue(httpContextKey, out var httpContextObject))
            {
                return httpContextObject as HttpContext;
            }

            return null;
        }
    }
}
