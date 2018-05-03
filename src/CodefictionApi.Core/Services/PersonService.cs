using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetPersonById(int id)
        {
            Person person = await _personRepository.GetPersonById(id);

            return person;
        }

        public async Task<Person> GetPersonByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Person person = await _personRepository.GetPersonByName(name);

            return person;
        }

        public async Task<IEnumerable<Person>> GetCrew()
        {
            IEnumerable<Person> crew = await _personRepository.GetCrew();

            return crew;
        }

        public async Task<IEnumerable<Person>> GetGuests()
        {
            IEnumerable<Person> guests = await _personRepository.GetGuests();

            return guests;
        }

        public async Task<IEnumerable<Person>> GetPeopleByNames(IList<string> names)
        {
            if (names == null)
            {
                throw new ArgumentNullException(nameof(names));
            }

            IEnumerable<Person> people = await _personRepository.GetPeopleByNames(names);

            return people;
        }
    }
}
