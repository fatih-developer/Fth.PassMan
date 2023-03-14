using Core.Utilities.Results;
using Entities.Concrete.EntityFramework;

namespace PassMan.UI
{
    public class CalendarListViewModel
    {
        public IDataResult<List<Calendar>> calendar { get; set; }
    }
}