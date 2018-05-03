using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Services
{
    public class MeetupModelMapper : IMeetupModelMapper
    {
        private readonly IPersonService _personService;
        private readonly IVideoService _videoService;
        private readonly ISponsorService _sponsorService;

        public MeetupModelMapper(IPersonService personService, IVideoService videoService, ISponsorService sponsorService)
        {
            _personService = personService;
            _videoService = videoService;
            _sponsorService = sponsorService;
        }

        public async Task<MeetupModel> Map(Meetup meetup)
        {
            if (meetup == null)
            {
                return null;
            }

            var meetupModel = Mapper.Map<MeetupModel>(meetup);

            if (meetup.Attendees != null && meetup.Attendees.Length > 0)
            {
                IEnumerable<Person> persons = await _personService.GetPeopleByNames(meetup.Attendees);
                meetupModel.Attendees = persons.ToArray();
            }

            if (meetup.VideoIds != null && meetup.VideoIds.Length > 0)
            {
                IEnumerable<VideoModel> videoModels = await _videoService.GetVideosByIds(meetup.VideoIds);
                meetupModel.Videos = videoModels.ToArray();
            }

            if (meetup.SponsorIds != null && meetup.SponsorIds.Length > 0)
            {
                IEnumerable<Sponsor> sponsors = await _sponsorService.GetSponsorsByIds(meetup.SponsorIds);
                meetupModel.Sponsors = sponsors.ToArray();
            }

            return meetupModel;
        }

        public async Task<IEnumerable<MeetupModel>> Map(IEnumerable<Meetup> meetups)
        {
            IList<MeetupModel> meetupModels = new List<MeetupModel>();

            foreach (Meetup meetup in meetups)
            {
                MeetupModel meetupModel = await Map(meetup);

                meetupModels.Add(meetupModel);
            }

            return meetupModels;
        }
    }
}
