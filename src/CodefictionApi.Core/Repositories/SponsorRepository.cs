using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public SponsorRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Sponsor> GetSponsorById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            Sponsor person = database.Sponsors.FirstOrDefault(s => s.Id == id);

            return person;
        }

        public async Task<Sponsor> GetSponsorByName(string name)
        {
            Database database = await _databaseProvider.GetDatabase();

            Sponsor person = database.Sponsors.FirstOrDefault(s => s.Name == name);

            return person;
        }

        public async Task<IEnumerable<Sponsor>> GetSponsors()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Sponsors;
        }

        public async Task<IEnumerable<Sponsor>> GetSponsorsByIds(IList<int> ids)
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Sponsor> sponsors = database.Sponsors.Where(sponsor => ids.Contains(sponsor.Id));

            return sponsors;
        }
    }
}
