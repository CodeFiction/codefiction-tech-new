using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Services.Mappers
{
    public class VideoModelMapper : IVideoModelMapper
    {
        private readonly IPersonService _personService;

        public VideoModelMapper(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<VideoModel> Map(IVideo video)
        {
            if (video == null)
            {
                return null;
            }

            var videoModel = Mapper.Map<VideoModel>(video);

            if (video.Attendees == null || video.Attendees.Length <= 0)
            {
                return videoModel;
            }

            IEnumerable<Person> people = await _personService.GetPeopleByNames(video.Attendees);
            videoModel.Attendees = people.ToArray();

            return videoModel;
        }

        public async Task<IEnumerable<VideoModel>> Map(IEnumerable<IVideo> videos)
        {
            if (videos == null)
            {
                return null;
            }

            IList<VideoModel> videoModels = new List<VideoModel>();

            foreach (IVideo video in videos)
            {
                VideoModel videoModel = await Map(video);

                videoModels.Add(videoModel);
            }

            return videoModels;
        }
    }
}
