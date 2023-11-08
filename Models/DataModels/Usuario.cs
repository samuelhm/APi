using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostArkOffice.Models.DataModels
{
    public class Usuario : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        
        public virtual ICollection<Personaje> Personajes { get; set; }

        [ForeignKey("Gremio")]
        public int? GremioId { get; set; }
        public virtual Gremio? Gremio { get; set; }
    }
}
