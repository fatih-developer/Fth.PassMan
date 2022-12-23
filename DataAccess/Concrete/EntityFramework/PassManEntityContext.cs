using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class PassManEntityContext:IdentityDbContext<User,Member,int>
{
    public PassManEntityContext(DbContextOptions<PassManEntityContext> options) : base(options)
    {

    }
}