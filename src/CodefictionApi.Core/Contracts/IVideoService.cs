using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core.Contracts
{
    public interface IVideoService
    {
        Task<VideoModel> GetVideoById(int id);

        Task<IEnumerable<VideoModel>> GetVideosByType(string type);

        Task<IEnumerable<VideoModel>> GetVideosByIds(IList<int> ids);
    }
}