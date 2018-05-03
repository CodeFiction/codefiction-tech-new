using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Repositories
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly IDatabaseProvider _databaseProvider;

        public PodcastRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<IEnumerable<Podcast>> GetPodcasts()
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

        public async Task<IEnumerable<P2P>> GetP2Ps()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.P2Ps;
        }

        public async Task<P2P> GetP2PBySlug(string slug)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.P2Ps.FirstOrDefault(podcast => podcast.Slug == slug);
        }

        public async Task<P2P> GetP2PById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.P2Ps.FirstOrDefault(podcast => podcast.Id == id);
        }

        public async Task<IEnumerable<Special>> GetSpecials()
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Specials;
        }

        public async Task<Special> GetSpecialBySlug(string slug)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Specials.FirstOrDefault(podcast => podcast.Slug == slug);
        }

        public async Task<Special> GetSpecialById(int id)
        {
            Database database = await _databaseProvider.GetDatabase();

            return database.Specials.FirstOrDefault(podcast => podcast.Id == id);
        }
    }
}
