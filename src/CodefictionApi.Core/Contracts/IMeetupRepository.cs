using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IMeetupRepository
    {
        Task<Meetup> GetMeetupById(int id);

        Task<IEnumerable<Meetup>> GetMeetups();
    }
}