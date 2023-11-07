using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostArkOffice.Models.DataModels;
namespace LostArkOffice.Models.DataModels
{
    public class Personaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public int ItemLevel { get; set; }

        public short? Habilidad { get; set; }

        [Required]
        [ForeignKey("ClaseDePersonaje")]
        public int ClaseDePersonajeId { get; set; }
        public virtual ClaseDePersonaje ClaseDePersonaje { get; set; }

        [Required]
        [ForeignKey("Propietario")]
        public string PropietarioId { get; set; }
        public virtual Usuario Propietario { get; set; }

        public virtual ICollection<PersonajeRaid> PersonajeRaids { get; set; }
    }
}
