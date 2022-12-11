using Framework.Entities;

namespace Entities.ComplexType
{
    public class UserLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}