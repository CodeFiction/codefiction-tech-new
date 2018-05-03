using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Services
{
    public class PodcastModelMapper : IPodcastModelMapper
    {
        private readonly IPersonService _personService;

        public PodcastModelMapper(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IPodcastModel> Map(IPodcast podcast)
        {
            if (podcast == null)
            {
                return null;
            }

            var podcastModel = Mapper.Map<PodcastModel>(podcast);

            if (podcast.Attendees != null && podcast.Attendees.Length > 0)
            {
                IEnumerable<Person> attendees = await _personService.GetPeopleByNames(podcast.Attendees);
                podcastModel.Attendees = attendees.ToArray();
            }

            if (!string.IsNullOrEmpty(podcast.Guest))
            {
                Person guest = await _personService.GetPersonByName(podcast.Guest);
                podcastModel.Guest = guest;
            }

            return podcastModel;
        }

        public async Task<IEnumerable<IPodcastModel>> Map(IEnumerable<IPodcast> podcasts)
        {
            if (podcasts == null)
            {
                return null;
            }

            IList<IPodcastModel> podcastModels = new List<IPodcastModel>();

            foreach (IPodcast podcast in podcasts)
            {
                IPodcastModel podcastModel = await Map(podcast);

                podcastModels.Add(podcastModel);
            }

            return podcastModels;
        }
    }
}