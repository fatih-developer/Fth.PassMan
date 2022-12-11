using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entities.ComplexTypes
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirition {  get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirition {  get; set; }   

    }
}
