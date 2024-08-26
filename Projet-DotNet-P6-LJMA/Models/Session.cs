using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("session")]
    public class Session
    {
        #region Propriétés d'identification
        [Column("id_session", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        #endregion

        #region Informations sur la session
        [Column("nom_session"), MaxLength(50)]
        public string? Nom { get; set; }

        [Column("date_debut_session")]
        public DateOnly Date_debut { get; set; }

        [Column("date_fin_session")]
        public DateOnly Date_fin { get; set; }

        [Column("randonnee_id", TypeName = "BINARY(16)"), ForeignKey(nameof(Randonnee))]
        public Guid RandonneeId { get; set; }

        [Column("theme_id", TypeName = "BINARY(16)"), ForeignKey(nameof(Theme))]
        public Guid ThemeId { get; set; }
        #endregion

        #region Propriétés de navigation
        /// <summary>
        /// Randonnée associée à la session.
        /// </summary>
        public virtual Randonnee Randonnee { get; set; }

        /// <summary>
        /// Thème associé à la session.
        /// </summary>
        public virtual Theme Theme { get; set; }
        #endregion
    }
}