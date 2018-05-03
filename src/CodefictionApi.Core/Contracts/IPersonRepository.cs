using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(int id);

        Task<Person> GetPersonByName(string name);

        Task<Person> GetPersonByEmail(string email);

        Task<IEnumerable<Person>> GetCrew();

        Task<IEnumerable<Person>> GetPeopleByNames(IList<string> names);

        Task<IEnumerable<Person>> GetPeopleByFilter(Func<Person, bool> func);

        Task<IEnumerable<Person>> GetGuests();
    }
}