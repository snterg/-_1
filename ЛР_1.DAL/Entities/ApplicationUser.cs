using Microsoft.AspNetCore.Identity;

namespace ЛР_1.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
