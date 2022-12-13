using Entities.Concrete;

namespace PassMan.UI
{
    public class PasswordSaveModel
    {
        public Passwords Password { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Clients { get; set; }
    }
}