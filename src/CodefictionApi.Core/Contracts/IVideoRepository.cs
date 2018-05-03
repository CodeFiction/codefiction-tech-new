using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IVideoRepository
    {
        Task<Video> GetVideoById(int id);

        Task<IEnumerable<Video>> GetVideos();

        Task<IEnumerable<Video>> GetVideosByType(string type);

        Task<IEnumerable<Video>> GetVideosByIds(IList<int> ids);
    }
}