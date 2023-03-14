using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Dals;
using Entities.Concrete.EntityFramework;

namespace Business.Concrete;

public class ControlManager:IControlService
{
    private IEfControlDal _controlDal;

    public ControlManager(IEfControlDal controlDal)
    {
        _controlDal = controlDal;
    }

    public IDataResult<List<Control>> GetAll()
    {
        return new SuccessDataResult<List<Control>>(_controlDal.GetList());
    }

    public IDataResult<Control> Get(int id)
    {
        return new SuccessDataResult<Control>(_controlDal.Get(p => p.Id == id));
    }

    public IDataResult<Control> Add(Control entity)
    {
        return new SuccessDataResult<Control>(_controlDal.Add(entity));
    }

    public IResult Update(Control entity)
    {
        _controlDal.Update(entity);
        return new SuccessResult(Messages.Updated);
    }

    public IResult Delete(Control entity)
    {
        _controlDal.Delete(entity);
        return new SuccessResult(Messages.Deleted);
    }

}