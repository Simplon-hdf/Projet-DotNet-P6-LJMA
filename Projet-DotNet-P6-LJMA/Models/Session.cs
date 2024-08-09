using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("session")]
    public class Session
    {
        [Column("id_session"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id{ get; set; }

        [Column("nom_session"), MaxLength(50)]
        public string? Nom { get; set; }

        [Column("date_debut_session")]
        public DateOnly Date_debut { get; set; }

        [Column("date_fin_session")]
        public DateOnly Date_fin { get; set; }

        [Column("id_rando"), ForeignKey("Randonnee"), Required]
        public Guid Id_rando { get; set; }
        [Column("id_theme"), ForeignKey("Theme"), Required]
        public Guid Id_theme { get; set; }

        #region Liaison de models
        public Randonnee Randonnee { get; set; }
        public Theme Theme { get; set; }
        #endregion
    }
}
