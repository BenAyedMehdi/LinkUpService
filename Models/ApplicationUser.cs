using Microsoft.AspNetCore.Identity;

namespace LinkUpSercice.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Roles will be managed by IdentityRole, so we don't need to add a property here
    }
}