namespace Core.Entities.ComplexTypes
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirition {  get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirition {  get; set; }   

    }
}
