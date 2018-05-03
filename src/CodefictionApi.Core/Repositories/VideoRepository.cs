using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public VideoRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Video> GetVideoById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            Video video = database.Videos.FirstOrDefault(v => v.Id == id);

            return video;
        }

        public async Task<IEnumerable<Video>> GetVideos()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Videos;
        }

        public async Task<IEnumerable<Video>> GetVideosByIds(IList<int> ids)
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Video> videos = database.Videos.Where(v => ids.Contains(v.Id));

            return videos;
        }

        public async Task<IEnumerable<Video>> GetVideosByType(string type)
        {
            Database database = await _databaseProvider.GetDatabase();

            IEnumerable<Video> videos = database.Videos.Where(v => v.Type == type);

            return videos;
        }
    }
}
