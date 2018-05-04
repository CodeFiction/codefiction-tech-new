using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers
{
    [Route("api/videos")]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        [Route("{type}")]
        public async Task<IActionResult> VideosByType(string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<VideoModel> videoModels = await _videoService.GetVideosByType(type);

            return Ok(videoModels);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> VideosByIds([FromQuery] IList<int> ids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<VideoModel> videoModels = await _videoService.GetVideosByIds(ids);

            return Ok(videoModels);
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> VideoById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VideoModel videoModel = await _videoService.GetVideoById(id);

            if (videoModel == null)
            {
                return NotFound();
            }

            return Ok(videoModel);
        }
    }
}
