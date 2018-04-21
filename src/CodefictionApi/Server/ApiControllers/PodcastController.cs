using System.Collections.Generic;
using System.Threading.Tasks;
using Codefiction.CodefictionTech.CodefictionApi.Server.Data;
using Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers
{
    [Route("api/podcasts")]
    public class PodcastController : Controller
    {
        private readonly IPodcastRepository _podcastRepository;

        public PodcastController(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<JsonResult> Podcasts()
        {
            IList<Podcast> podcasts = await _podcastRepository.GetPodcasts();

            return new JsonResult(podcasts);
        }
    }
}
