using Core.DataAccess;
using Entities.Concrete.EntityFramework;

namespace DataAccess.Abstract;

public interface IEfConnectionDal: IEntityRepository<Connection>
{
    
}