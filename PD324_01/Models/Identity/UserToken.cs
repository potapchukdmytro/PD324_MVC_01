using Microsoft.AspNetCore.Identity;

namespace PD324_01.Models.Identity
{
    public class UserToken : IdentityUserToken<int>
    {
        public virtual User User { get; set; }
    }
}
