using Core.Utilities.Results;
using Entities.Concrete.EntityFramework;

namespace PassMan.UI.Models
{
    public class CustomerListViewModel
    {
        public IDataResult<List<Customer>> customer { get; set; }
    }
}