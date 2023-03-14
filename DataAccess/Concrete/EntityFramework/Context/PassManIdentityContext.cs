using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;

public class PassManIdentityContext:IdentityDbContext<User,Member,int>
{
    public PassManIdentityContext(DbContextOptions<PassManIdentityContext> options) : base(options)
    {

    }

   

   

}