using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Data.Models
{
    [Table("reserver")]
    public class Reserver
    {
        #region Propriétés d'identification
        [Column("id_reserver"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationId { get; set; }
        #endregion

        #region Informations sur la réservation
        [Column("utilisateur_id", TypeName = "BINARY(16)"), ForeignKey(nameof(Utilisateur))]
        public Guid UtilisateurId { get; set; }

        [Column("session_id", TypeName = "BINARY(16)"), ForeignKey(nameof(Session))]
        public Guid SessionId { get; set; }

        [Column("nb_participant")]
        public int ParticipantNb { get; set; }
        #endregion

        #region Propriétés de navigation
        /// <summary>
        /// Utilisateur qui a effectué la réservation.
        /// </summary>
        public virtual Utilisateur Utilisateur { get; set; }

        /// <summary>
        /// Session réservée.
        /// </summary>
        public virtual Session Session { get; set; }
        #endregion
    }
}