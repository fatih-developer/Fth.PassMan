using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Dals;
using Entities.Concrete.EntityFramework;

namespace Business.Concrete;

public class ConnectionManager:IConnectionService
{
    private IEfConnectionDal _connectionDal;

    public ConnectionManager(IEfConnectionDal connectionDal)
    {
        _connectionDal = connectionDal;
    }


    public IDataResult<List<Connection>> GetAll()
    {
        return new SuccessDataResult<List<Connection>>(_connectionDal.GetList());
    }

    public IDataResult<Connection> Get(int id)
    {
        return new SuccessDataResult<Connection>(_connectionDal.Get(p => p.Id == id));
    }

    public IDataResult<Connection> Add(Connection entity)
    {
        return new SuccessDataResult<Connection>(_connectionDal.Add(entity));
    }

    public IResult Update(Connection entity)
    {
        _connectionDal.Update(entity);
        return new SuccessResult(Messages.Updated);
    }

    public IResult Delete(Connection entity)
    {
        _connectionDal.Delete(entity);
        return new SuccessResult(Messages.Deleted);
    }
}