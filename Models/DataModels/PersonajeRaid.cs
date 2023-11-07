using System.ComponentModel.DataAnnotations.Schema;

namespace LostArkOffice.Models.DataModels
{
    public class PersonajeRaid
    {
        [ForeignKey("Personaje")]
        public int PersonajeId { get; set; }
        public virtual Personaje Personaje { get; set; }

        [ForeignKey("TipoDeRaid")]
        public int TipoDeRaidId { get; set; }
        public virtual TipoDeRaid TipoDeRaid { get; set; }
    }
}
