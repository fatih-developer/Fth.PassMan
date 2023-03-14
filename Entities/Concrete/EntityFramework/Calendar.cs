using Core.Entities;

namespace Entities.Concrete.EntityFramework;

public class Calendar:IEntity
{
    public Calendar()
    {
        this.Plans = new List<Plan>();
    }

    public int Id { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Week { get; set; }

    public ICollection<Plan> Plans { get; set; }
}