using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlazorShop.Api.Context
{
    public class AppDbContextIdentity : IdentityDbContext<IdentityUser>
    {
        public AppDbContextIdentity(DbContextOptions<AppDbContextIdentity> options)
            : base(options)
        { }
    }
}