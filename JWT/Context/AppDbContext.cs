using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JWT.Models;

namespace JWT.Context
{
    //public class AppDbContext :IdentityDbContext<ApplicationUser>
    //{

    //    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    //    {

    //    }

    //}

    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
