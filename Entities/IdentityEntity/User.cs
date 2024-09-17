
using Microsoft.AspNetCore.Identity;

namespace Entities.IdentityEntity
{
    public class User:IdentityUser<Guid>
    {
        public String? PersonName {  get; set; }

    }
}
