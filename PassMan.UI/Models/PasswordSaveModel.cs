using Entities.Concrete;
using Entities.Concrete.MongoDb;

namespace PassMan.UI.Models
{
    public class PasswordSaveModel
    {
        public Passwords Password { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Clients { get; set; }
    }
}