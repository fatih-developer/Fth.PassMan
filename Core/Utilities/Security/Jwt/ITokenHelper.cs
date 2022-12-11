using Core.Entities.Concrete;
using System.Collections.Generic;

namespace MainCore.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
