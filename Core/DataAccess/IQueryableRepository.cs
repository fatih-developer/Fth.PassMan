using System.Linq;
using Core.Entities;
using Framework.Entities;

namespace Core.DataAccess
{
    public interface IQueryableRepository<T> where T: class, IEntity, new()
    {
        IQueryable<T> Table { get; }

    }
}