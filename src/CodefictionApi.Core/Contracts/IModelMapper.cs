using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodefictionApi.Core.Contracts
{
    public interface IModelMapper<in TEntity, TModel>
    {
        Task<TModel> Map(TEntity entity);

        Task<IEnumerable<TModel>> Map(IEnumerable<TEntity> entities);
    }
}