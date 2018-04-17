using System.Threading;
using System.Threading.Tasks;
using Codefiction.CodefictionTech.CodefictionApi.Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
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
                return httpContextObject as HttpContext;

            return null;
        }

        public static async Task<RenderToStringResult> BuildPrerender(this NancyContext context)
        {
            // for production, enable server side renderring

            HttpContext httpContext = context.GetHttpContext();

            var hostingEnvironment = context.GetRequiredService<IHostingEnvironment>();

            var applicationBasePath = hostingEnvironment.ContentRootPath;
            var requestFeature = context.GetFeature<IHttpRequestFeature>();
            var unencodedPathAndQuery = requestFeature.RawTarget;
            var unencodedAbsoluteUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{unencodedPathAndQuery}";

            TransferData transferData = new TransferData
            {
                // By default we're passing down Cookies, Headers, Host from the Request object here
                request = AbstractHttpContextRequestInfo(httpContext.Request)
                // ex:
                // transferData.thisCameFromDotNET = "Hi Angular it's asp.net :)";
                // Add more customData here, add it to the TransferData class
            };

            var nodeService = context.GetRequiredService<INodeServices>(); // nodeServices

            CancellationTokenSource cancelSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelSource.Token;

            // Prerender / Serialize application (with Universal)
            var prerenderResult = await Prerenderer.RenderToString(
                "/",
                nodeService,
                //Request.HttpContext.RequestServices.GetRequiredService<INodeServices>(), // nodeServices
                cancelToken,
                new JavaScriptModuleExport(applicationBasePath + "/CodefictionApp/dist-server/main.bundle"),
                unencodedAbsoluteUrl,
                unencodedPathAndQuery,
                transferData, // Our simplified Request object & any other CustommData you want to send!
                30000,
                httpContext.Request.PathBase.ToString()
            );

            return prerenderResult;
        }

        private static SimplifiedRequest AbstractHttpContextRequestInfo(HttpRequest request)
        {
            return new SimplifiedRequest
            {
                cookies = request.Cookies,
                headers = request.Headers,
                host = request.Host
            };
        }
    }
}