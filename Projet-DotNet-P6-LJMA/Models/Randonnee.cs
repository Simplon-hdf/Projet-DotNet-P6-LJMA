using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Randonnee de la BDD.
    /// </summary>
    [Table("Randonnee")]
    public class Randonnee
    {
        [Column("id"),Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required, MaxLength(36)]
        public Guid id_rando { get; set; }
        [Column("prix_rando"),Required]
        public decimal prix_rando { get; set; }
        [Column("desc_rando"),Required]
        public string desc_rando { get; set; }
        [Column("lieu_rando"), Required, MaxLength(50)]
        public string lieu_rando { get; set; }
        [Column("image_rando"), Required, MaxLength(2000)]
        public string image_rando { get; set; }
        [Column("nb_nuit_rando")]
        public int nb_nuit_rando { get; set; }
        [Column("nb_jour_rando"), Required]
        public int nb_jour_rando { get; set; }
        [Column("limite_participant"), Required]
        public int limite_participant { get; set; }

    }
}
