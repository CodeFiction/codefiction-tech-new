using System.Threading;
using System.Threading.Tasks;
using Codefiction.CodefictionTech.CodefictionApi.Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Microsoft.Extensions.DependencyInjection;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Helpers
{
    public static class HttpRequestExtensions
    {
        public static SimplifiedRequest AbstractRequestInfo(this HttpRequest request)
        {
            return new SimplifiedRequest
            {
                cookies = request.Cookies,
                headers = request.Headers,
                host = request.Host
            };
        }

        public static async Task<RenderToStringResult> BuildPrerender(this HttpRequest request)
        {
            var nodeServices = request.HttpContext.RequestServices.GetRequiredService<INodeServices>();
            var hostEnv = request.HttpContext.RequestServices.GetRequiredService<IHostingEnvironment>();

            var applicationBasePath = hostEnv.ContentRootPath;
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            var unencodedPathAndQuery = requestFeature.RawTarget;
            var unencodedAbsoluteUrl = $"{request.Scheme}://{request.Host}{unencodedPathAndQuery}";

            // ** TransferData concept **
            // Here we can pass any Custom Data we want !

            // By default we're passing down Cookies, Headers, Host from the Request object here
            TransferData transferData = new TransferData
            {
                request = request.AbstractRequestInfo(),
                thisCameFromDotNET = "Hi Angular it's asp.net :)"
            };
            // Add more customData here, add it to the TransferData class

            //Prerender now needs CancellationToken
            CancellationTokenSource cancelSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelSource.Token;

            // Prerender / Serialize application (with Universal)
            return await Prerenderer.RenderToString(
                "/",
                nodeServices,
                cancelToken,
                new JavaScriptModuleExport(applicationBasePath + "/CodefictionApp/dist-server/main.bundle"),
                unencodedAbsoluteUrl,
                unencodedPathAndQuery,
                transferData, // Our simplified Request object & any other CustommData you want to send!
                30000,
                request.PathBase.ToString()
            );
        }
    }
}
