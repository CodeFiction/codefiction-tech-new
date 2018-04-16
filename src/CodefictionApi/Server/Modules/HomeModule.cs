using System.Threading;
using Codefiction.CodefictionTech.CodefictionApi.Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Nancy;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Modules
{
    public sealed class HomeModule : NancyModule
    {
        public HomeModule(IHostingEnvironment hostingEnvironment)
        {
            Get("/api/start", o => "OK");

            Get("/", async o =>
            {
                // for production, enable server side renderring

                HttpContext httpContext = Context.GetHttpContext();

                var applicationBasePath = hostingEnvironment.ContentRootPath;
                var requestFeature = Context.GetFeature<IHttpRequestFeature>();
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

                var nodeService = Context.GetRequiredService<INodeServices>(); // nodeServices

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

                IndexViewModel indexViewModel = new IndexViewModel
                {
                    SpaHtml = prerenderResult.Html, // our <app> from Angular
                    Title = prerenderResult.Globals["title"].ToString(), // set our <title> from Angular
                    Styles = prerenderResult.Globals["styles"].ToString(), // put styles in the correct place
                    Meta = prerenderResult.Globals["meta"].ToString(), // set our <meta> SEO tags
                    Links = prerenderResult.Globals["links"].ToString(), // set our <link rel="canonical"> etc SEO tags
                    TransferDataWindow = prerenderResult.Globals["transferData"].ToString() // our transfer data set to window.TRANSFER_CACHE = {};
                };

                return View["index.sshtml", indexViewModel];
            });
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
