using System.ComponentModel.DataAnnotations.Schema;

namespace LostArkOffice.Models.DataModels
{
    public class RaidPersonaje
    {
        public int RaidId { get; set; }
        [ForeignKey("RaidId")]
        public virtual Raid Raid { get; set; }

        public int PersonajeId { get; set; }

        [ForeignKey("PersonajeId")]
        public virtual Personaje Personaje { get; set; }
    }
}
