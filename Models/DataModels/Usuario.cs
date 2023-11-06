using Microsoft.AspNetCore.Identity;

namespace LostArkOffice.Models.DataModels
{
    public class Usuario : IdentityUser
    {
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}
