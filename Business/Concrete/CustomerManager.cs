using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.EntityFramework;

namespace Business.Concrete;

public class CustomerManager:ICustomerService
{
    private IEfCustomerDal _customerDal;

    public CustomerManager(IEfCustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetList());
    }

    public IDataResult<Customer> Get(int id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == id));
    }

    public IDataResult<Customer> Add(Customer entity)
    {
        return new SuccessDataResult<Customer>(_customerDal.Add(entity));
    }

    public IResult Update(Customer entity)
    {
        _customerDal.Update(entity);
        return new SuccessResult(Messages.Updated);
    }

    public IResult Delete(Customer entity)
    {
        _customerDal.Delete(entity);
        return new SuccessResult(Messages.Deleted);
    }
}