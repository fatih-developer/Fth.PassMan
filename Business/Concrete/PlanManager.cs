using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Dals;
using Entities.Concrete.EntityFramework;

namespace Business.Concrete;

public class PlanManager:IPlanService
{
    private readonly IEfPlanDal _planDal;

    public PlanManager(IEfPlanDal planDal)
    {
        _planDal = planDal;
    }

    public IDataResult<List<Plan>> GetAll()
    {
        return new SuccessDataResult<List<Plan>>(_planDal.GetList());
    }

    public IDataResult<Plan> Get(int id)
    {
        return new SuccessDataResult<Plan>(_planDal.Get(p => p.Id == id));
    }

    public IDataResult<Plan> Add(Plan entity)
    {
        return new SuccessDataResult<Plan>(_planDal.Add(entity));
    }

    public IResult Update(Plan entity)
    {
        _planDal.Update(entity);
        return new SuccessResult(Messages.Updated);
    }

    public IResult Delete(Plan entity)
    {
        _planDal.Delete(entity);
        return new SuccessResult(Messages.Deleted);
    }

}