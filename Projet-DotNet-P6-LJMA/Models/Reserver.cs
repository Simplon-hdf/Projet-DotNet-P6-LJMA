using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Reserver de la BDD.
    /// </summary>
    [Table("Reserver")]
    public class Reserver
	{
        [Column("id"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid reservationId { get; set; }
        [Column("id_utilisateur"), ForeignKey("id_utilisateur"), Required]
		public Guid utilisateurId { get; set; }
        [Column("id_session"), ForeignKey("id_session"), Required]
		public Guid sessionId { get; set; }
        [Column("nb_participant"), Required]
		public int participantNb {  get; set; }

        #region Liaison de models
        public Session? Session { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        #endregion
    }
}