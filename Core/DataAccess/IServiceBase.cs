using System.Collections.Generic;
using MainCore.Utilities.Results;

namespace MainCore.DataAccess
{
    public interface IServiceBase<T>
    {
        IDataResult<List<T>> GetAll();

        IDataResult<T> Get(int id);

        IDataResult<T> Add(T entity);

        IResult Update(T entity);

        IResult Delete(T entity);

    }
}