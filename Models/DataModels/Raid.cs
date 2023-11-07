using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LostArkOffice.Models.DataModels
{
    public class Raid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromHours(1); // Valor predeterminado de 1 hora
        public bool Finished { get; set; } = false;

        [ForeignKey("TipoDeRaid")]
        public int TipoDeRaidId { get; set; }
        public TipoDeRaid TipoDeRaid { get; set; }

        public virtual ICollection<RaidPersonaje> RaidPersonajes { get; set; } = new List<RaidPersonaje>();
    }
}
