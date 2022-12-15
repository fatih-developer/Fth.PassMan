using Entities.Concrete;

namespace PassMan.UI.Models;

public class PassShowViewModel
{
    public byte[] imageData;

    public Passwords Passwords { get; set; }

    public string Pass { get; set; }
}