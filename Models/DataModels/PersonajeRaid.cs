using System.ComponentModel.DataAnnotations.Schema;

namespace LostArkOffice.Models.DataModels
{
    public class PersonajeRaid
    {
        public int PersonajeId { get; set; }
        [ForeignKey("PersonajeId")]
        public virtual Personaje Personaje { get; set; }

        public int TipoDeRaidId { get; set; }
        [ForeignKey("TipoDeRaidId")]
        public virtual TipoDeRaid TipoDeRaid { get; set; }
    }
}
