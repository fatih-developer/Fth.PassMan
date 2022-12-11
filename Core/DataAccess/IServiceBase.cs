using Core.Utilities.Results;

namespace Core.DataAccess
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