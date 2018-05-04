using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers
{
    [Route("api/sponsors")]
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Sponsors()
        {
            IEnumerable<Sponsor> sponsors = await _sponsorService.GetSponsors();

            return Ok(sponsors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> SponsorById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sponsor sponsor = await _sponsorService.GetSponsorById(id);

            if (sponsor == null)
            {
                return NotFound();
            }

            return Ok(sponsor);
        }
    }
}
