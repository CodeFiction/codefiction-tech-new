using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface ISponsorRepository
    {
        Task<Sponsor> GetSponsorById(int id);

        Task<Sponsor> GetSponsorByName(string name);

        Task<IEnumerable<Sponsor>> GetSponsors();

        Task<IEnumerable<Sponsor>> GetSponsorsByIds(IList<int> ids);
    }
}