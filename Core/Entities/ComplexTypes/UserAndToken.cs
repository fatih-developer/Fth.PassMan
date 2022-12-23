namespace Core.Entities.ComplexTypes
{
    public class UserAndToken
    {
        public UserDetailDto UserDataDto { get; set; }
        public string Token { get; set; }
        public string TokenDate { get; set; }
    }
}