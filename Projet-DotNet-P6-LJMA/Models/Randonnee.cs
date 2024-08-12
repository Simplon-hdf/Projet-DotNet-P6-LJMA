using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("Randonnee")]
    public class Randonnee
    {
        [Column("id_randonnee", TypeName = "BINARY(16)"),Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid Id { get; set; }
        [Column("prix_rando"),Required]
        public decimal Prix { get; set; }
        [Column("desc_rando"),Required]
        public string Desc { get; set; }
        [Column("lieu_rando"), Required, MaxLength(50)]
        public string Lieu { get; set; }
        [Column("image_rando"), Required, MaxLength(2000)]
        public string Image { get; set; }
        [Column("nb_nuit_rando")]
        public int Nb_nuit { get; set; }
        [Column("nb_jour_rando"), Required]
        public int Nb_jour { get; set; }
        [Column("limite_participant"), Required]
        public int Limite_participant { get; set; }
    }
}
