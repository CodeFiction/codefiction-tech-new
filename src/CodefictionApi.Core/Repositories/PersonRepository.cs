using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public PersonRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Person> GetPersonById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            Person person = database.People.FirstOrDefault(p => p.Id == id);

            return person;
        }

        public async Task<Person> GetPersonByName(string name)
        {
            Database database = await _databaseProvider.GetDatabase();

            Person person = database.People.FirstOrDefault(p => p.Name == name);

            return person;
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            Database database = await _databaseProvider.GetDatabase();

            Person person = database.People.FirstOrDefault(p => p.Name == email);

            return person;
        }

        public async Task<IEnumerable<Person>> GetCrew()
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Person> people = database.People.Where(person => person.Type == "Crew");

            return people;
        }

        public async Task<IEnumerable<Person>> GetGuests()
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Person> people = database.People.Where(person => person.Type == "Guest");

            return people;
        }

        public async Task<IEnumerable<Person>> GetPeopleByNames(IList<string> names)
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Person> people = database.People.Where(person => names.Contains(person.Name));

            return people;
        }

        public async Task<IEnumerable<Person>> GetPeopleByFilter(Func<Person, bool> func)
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Person> people = database.People.Where(func);

            return people;
        }
    }
}
