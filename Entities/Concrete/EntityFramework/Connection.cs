using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.EntityFramework;

public class Connection : IEntity
{
    public int Id { get; set; }
    public int RfCustomer { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ConnectionType { get; set; }
    
    [ForeignKey("RfCustomer")]
    public Customer Customers { get; set; }
}