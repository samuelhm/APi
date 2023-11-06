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
        public int ClaseDePersonajeId { get; set; }
        [ForeignKey("ClaseDePersonajeId")]
        public virtual ClaseDePersonaje Clase { get; set; }

        [Required]
        public string PropietarioId { get; set; }
        [ForeignKey("PropietarioId")]
        public virtual Usuario Propietario { get; set; }

        public virtual ICollection<PersonajeRaid> PersonajeRaids { get; set; }
    }
}
