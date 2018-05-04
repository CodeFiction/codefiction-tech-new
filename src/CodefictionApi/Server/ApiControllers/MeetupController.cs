using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers
{
    [Route("api/meetups")]
    public class MeetupController : Controller
    {
        private readonly IMeetupService _meetupService;

        public MeetupController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Meetups()
        {
            IEnumerable<MeetupModel> meetupModels = await _meetupService.GetMeetups();

            return Ok(meetupModels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> MeetupById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MeetupModel meetupModel = await _meetupService.GetMeetupById(id);

            if (meetupModel == null)
            {
                return NotFound();
            }

            return Ok(meetupModel);
        }
    }
}
