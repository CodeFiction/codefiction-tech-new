using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoModelMapper _videoModelMapper;

        public VideoService(IVideoRepository videoRepository, IVideoModelMapper videoModelMapper)
        {
            _videoRepository = videoRepository;
            _videoModelMapper = videoModelMapper;
        }

        public async Task<VideoModel> GetVideoById(int id)
        {
            Video video = await _videoRepository.GetVideoById(id);
            VideoModel videoModel = await _videoModelMapper.Map(video);

            return videoModel;
        }

        public async Task<IEnumerable<VideoModel>> GetVideosByType(string type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            IEnumerable<Video> videos = await _videoRepository.GetVideosByType(type);
            IEnumerable<VideoModel> videoModels = await _videoModelMapper.Map(videos);

            return videoModels;
        }

        public async Task<IEnumerable<VideoModel>> GetVideosByIds(IList<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            IEnumerable<Video> videos = await _videoRepository.GetVideosByIds(ids);
            IEnumerable<VideoModel> videoModels = await _videoModelMapper.Map(videos);

            return videoModels;
        }
    }
}
