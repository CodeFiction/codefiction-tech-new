using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IPersonService
    {
        Task<Person> GetPersonById(int id);

        Task<Person> GetPersonByName(string name);

        Task<IEnumerable<Person>> GetCrew();

        Task<IEnumerable<Person>> GetGuests();

        Task<IEnumerable<Person>> GetPeopleByNames(IList<string> names);
    }
}