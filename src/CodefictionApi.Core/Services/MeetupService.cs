using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Services
{
    public class MeetupService : IMeetupService
    {
        private readonly IMeetupRepository _meetupRepository;
        private readonly IMeetupModelMapper _meetupModelMapper;

        public MeetupService(IMeetupRepository meetupRepository, IMeetupModelMapper meetupModelMapper)
        {
            _meetupRepository = meetupRepository;
            _meetupModelMapper = meetupModelMapper;
        }

        public async Task<IEnumerable<MeetupModel>> GetMeetups()
        {
            IEnumerable<Meetup> meetups = await _meetupRepository.GetMeetups();
            IEnumerable<MeetupModel> meetupModels = await _meetupModelMapper.Map(meetups);

            return meetupModels;
        }

        public async Task<MeetupModel> GetMeetupById(int id)
        {
            Meetup meetup = await _meetupRepository.GetMeetupById(id);
            MeetupModel meetupModel = await _meetupModelMapper.Map(meetup);

            return meetupModel;
        }
    }
}
