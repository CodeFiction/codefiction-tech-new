using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IPodcastRepository
    {
        Task<IEnumerable<Podcast>> GetPodcasts();

        Task<Podcast> GetPodcastById(int id);

        Task<Podcast> GetPodcastBySlug(string slug);

        Task<IEnumerable<P2P>> GetP2Ps();

        Task<P2P> GetP2PBySlug(string slug);

        Task<P2P> GetP2PById(int id);

        Task<IEnumerable<Special>> GetSpecials();

        Task<Special> GetSpecialBySlug(string slug);

        Task<Special> GetSpecialById(int id);
    }
}