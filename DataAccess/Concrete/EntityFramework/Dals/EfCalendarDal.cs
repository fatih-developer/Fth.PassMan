using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete.EntityFramework;

namespace DataAccess.Concrete.EntityFramework.Dals;

public class EfCalendarDal:EfEntityRepositoryBase<Calendar,PassManContext>,IEfCalendarDal
{
    
}