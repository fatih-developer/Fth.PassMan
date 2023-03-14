using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete.EntityFramework;

namespace Business.Abstract
{
    public interface IConnectionService:IServiceBase<Connection>
    {
    }
}
