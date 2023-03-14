using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete.EntityFramework;

public class Control:IEntity
{
    public int Id { get; set; }
    public int RfCustomer { get; set; }
    public int RfPlan { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PrevData { get; set; }
    public string LastData { get; set; }
    public bool Warning { get; set; }
    public string Todo { get; set; }

    [ForeignKey("RfCustomer")]
    public Customer Customers { get; set; }
    
    [ForeignKey("RfPlan")]
    public Plan Plan { get; set; }
}