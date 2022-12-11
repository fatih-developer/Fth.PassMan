using Framework.Entities;
using System;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

    }
}
