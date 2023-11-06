using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LostArkOffice.Models.DataModels
{
    public class Usuario : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}
