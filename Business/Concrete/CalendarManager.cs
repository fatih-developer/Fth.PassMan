using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.EntityFramework;

namespace Business.Concrete;

public class CalendarManager:ICalendarService
{
    private IEfCalendarDal _calendarDal;

    public CalendarManager(IEfCalendarDal calendarDal)
    {
        _calendarDal = calendarDal;
    }

    public IDataResult<List<Calendar>> GetAll()
    {
        return new SuccessDataResult<List<Calendar>>(_calendarDal.GetList());
    }

    public IDataResult<Calendar> Get(int id)
    {
        return new SuccessDataResult<Calendar>(_calendarDal.Get(p=>p.Id == id));
    }

    public IDataResult<Calendar> Add(Calendar entity)
    {
        return new SuccessDataResult<Calendar>(_calendarDal.Add(entity));
    }

    public IResult Update(Calendar entity)
    {
        _calendarDal.Update(entity);
        return new SuccessResult(Messages.Updated);
    }

    public IResult Delete(Calendar entity)
    {
        _calendarDal.Delete(entity);
        return new SuccessResult(Messages.Deleted);
    }
}