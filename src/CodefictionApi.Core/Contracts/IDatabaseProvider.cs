using System.Threading.Tasks;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
{
    public interface IDatabaseProvider
    {
        Task<Database> GetDatabase();
    }
}