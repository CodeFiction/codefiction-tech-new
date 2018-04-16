using Microsoft.AspNetCore.Hosting;
using Nancy;

namespace Codefiction.CodefictionTech.CodefictionApi.Server
{
    public class AppRootPathProvider : IRootPathProvider
    {
        private readonly IHostingEnvironment _environment;

        public AppRootPathProvider(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public string GetRootPath()
        {
            return _environment.WebRootPath;
        }
    }
}
