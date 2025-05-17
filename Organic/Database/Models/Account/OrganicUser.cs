using Microsoft.AspNetCore.Identity;

namespace Organic.Database.Models.Account;

public class OrganicUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
