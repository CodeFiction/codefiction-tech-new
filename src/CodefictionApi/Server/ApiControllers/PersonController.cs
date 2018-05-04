using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers
{
    [Route("api/people")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("/crew")]
        public async Task<IActionResult> Crew()
        {
            IEnumerable<Person> crew = await _personService.GetCrew();

            return Ok(crew);
        }

        [HttpGet]
        [Route("/guests")]
        public async Task<IActionResult> Guests()
        {
            IEnumerable<Person> guests = await _personService.GetGuests();

            return Ok(guests);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> PersonByName(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = await _personService.GetPersonByName(name);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> PeopleByNames([FromQuery]IList<string> names)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Person> persons = await _personService.GetPeopleByNames(names);

            return Ok(persons);
        }
    }
}