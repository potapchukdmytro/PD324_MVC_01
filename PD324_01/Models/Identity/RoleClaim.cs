using Microsoft.AspNetCore.Identity;

namespace PD324_01.Models.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}
