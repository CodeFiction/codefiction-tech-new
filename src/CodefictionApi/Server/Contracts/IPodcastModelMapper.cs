using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Contracts
{
    public interface IPodcastModelMapper
    {
        Task<PodcastModel> Map(Podcast podcast);

        Task<IEnumerable<PodcastModel>> Map(IEnumerable<Podcast> podcasts);
    }
}