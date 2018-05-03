using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Repositories
{
    public class MeetupRepository : IMeetupRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public MeetupRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Meetup> GetMeetupById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            Meetup meetup = database.Meetups.FirstOrDefault(m => m.Id == id);

            return meetup;
        }

        public async Task<IEnumerable<Meetup>> GetMeetups()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Meetups;
        }
    }
}
