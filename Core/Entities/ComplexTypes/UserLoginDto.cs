namespace Core.Entities.ComplexTypes
{
    public class UserLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}