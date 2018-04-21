using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public PodcastRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<IList<Podcast>> GetPodcasts()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Podcasts;
        }

        public async Task<Podcast> GetPodcastBySlug(string slug)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Podcasts.FirstOrDefault(podcast => podcast.Slug == slug);
        }

        public async Task<Podcast> GetPodcastById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Podcasts.FirstOrDefault(podcast => podcast.Id == id);
        }
    }
}
