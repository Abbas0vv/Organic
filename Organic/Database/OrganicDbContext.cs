using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organic.Database.Models;
using Organic.Database.Models.Account;

namespace Organic.Database;

public class OrganicDbContext : IdentityDbContext<OrganicUser, OrganicRole, int>
{
    public OrganicDbContext(DbContextOptions<OrganicDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
