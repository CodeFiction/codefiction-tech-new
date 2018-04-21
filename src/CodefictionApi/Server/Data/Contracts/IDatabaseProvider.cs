using System.Threading.Tasks;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts
{
    public interface IDatabaseProvider
    {
        Task<Database> GetDatabase();
    }
}