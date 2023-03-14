using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Entities.Concrete.EntityFramework;

public class Plan:IEntity
{
    public Plan()
    {
        this.Controls = new List<Control>();
    }

    public int Id { get; set; }
    public int RfCalendar { get; set; }
    public int RfCustomer { get; set; }
    public bool Start { get; set; }
    public bool End { get; set; }


    [ForeignKey("RfCustomer")]
    public Customer Customers { get; set; }

    [ForeignKey("RfCalendar")]
    public Calendar Calendar { get; set; }


    public ICollection<Control> Controls { get; set; }
}