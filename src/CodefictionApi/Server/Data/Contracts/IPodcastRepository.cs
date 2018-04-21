using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts
{
    public interface IPodcastRepository
    {
        Task<Podcast> GetPodcastById(int id);

        Task<Podcast> GetPodcastBySlug(string slug);

        Task<IList<Podcast>> GetPodcasts();
    }
}