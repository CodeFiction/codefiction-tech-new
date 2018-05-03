using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Contracts
{
    public interface IMeetupService
    {
        Task<IEnumerable<MeetupModel>> GetMeetups();

        Task<MeetupModel> GetMeetupById(int id);
    }
}