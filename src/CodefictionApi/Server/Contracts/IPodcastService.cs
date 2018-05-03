using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Models;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Contracts
{
    public interface IPodcastService
    {
        Task<IEnumerable<PodcastModel>> GetPodcasts();

        Task<PodcastModel> GetPodcastBySlug(string slug);
    }
}