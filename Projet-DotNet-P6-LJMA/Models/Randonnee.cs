using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("randonnee")]
    public class Randonnee
    {
        #region Propriétés d'identification
        [Column("id_randonnee", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        #endregion

        #region Informations sur la randonnée
        [Column("prix_rando")]
        public decimal Prix { get; set; }

        [Column("desc_rando")]
        public string Desc { get; set; }

        [Column("lieu_rando"), MaxLength(50)]
        public string Lieu { get; set; }

        [Column("image_rando"), MaxLength(2000)]
        public string Image { get; set; }

        [Column("nb_nuit_rando")]
        public int Nb_nuit { get; set; }

        [Column("nb_jour_rando")]
        public int Nb_jour { get; set; }

        [Column("limite_participant")]
        public int Limite_participant { get; set; }
        #endregion
    }
}