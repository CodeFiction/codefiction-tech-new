using Codefiction.CodefictionTech.CodefictionApi.Server.Model;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Nancy;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Modules
{
    public sealed class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/api/start", o => "OK");

            Get("/", async o =>
            {
                RenderToStringResult prerenderResult = await Context.BuildPrerender();
                IndexViewModel indexViewModel = GetIndexModel(prerenderResult);

                return View["index.sshtml", indexViewModel];
            });

            Get("/home", async o =>
            {
                RenderToStringResult prerenderResult = await Context.BuildPrerender();
                IndexViewModel indexViewModel = GetIndexModel(prerenderResult);

                return View["index.sshtml", indexViewModel];
            });
        }

        private IndexViewModel GetIndexModel(RenderToStringResult prerenderResult)
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                SpaHtml = prerenderResult.Html, // our <app> from Angular
                Title = prerenderResult.Globals["title"].ToString(), // set our <title> from Angular
                Styles = prerenderResult.Globals["styles"].ToString(), // put styles in the correct place
                Meta = prerenderResult.Globals["meta"].ToString(), // set our <meta> SEO tags
                Links = prerenderResult.Globals["links"].ToString(), // set our <link rel="canonical"> etc SEO tags
                TransferDataWindow =prerenderResult.Globals["transferData"].ToString() // our transfer data set to window.TRANSFER_CACHE = {};
            };

            return indexViewModel;
        }
    }
}
