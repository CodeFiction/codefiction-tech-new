using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorService(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<Sponsor> GetSponsorById(int id)
        {
            Sponsor sponsor = await _sponsorRepository.GetSponsorById(id);

            return sponsor;
        }

        public async Task<Sponsor> GetSponsorByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Sponsor sponsor = await _sponsorRepository.GetSponsorByName(name);

            return sponsor;
        }

        public async Task<IEnumerable<Sponsor>> GetSponsors()
        {
            IEnumerable<Sponsor> sponsors = await _sponsorRepository.GetSponsors();

            return sponsors;
        }

        public async Task<IEnumerable<Sponsor>> GetSponsorsByIds(IList<int> ids)
        {
            IEnumerable<Sponsor> sponsors = await _sponsorRepository.GetSponsorsByIds(ids);

            return sponsors;
        }
    }
}
