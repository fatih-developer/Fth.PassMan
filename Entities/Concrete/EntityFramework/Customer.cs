using Core.Entities;

namespace Entities.Concrete.EntityFramework;

public class Customer:IEntity
{

    public Customer()
    {
        this.Connections = new List<Connection>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Connection> Connections { get; set; }

}
