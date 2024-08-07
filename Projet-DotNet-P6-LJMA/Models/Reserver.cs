using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Reserver de la BDD.
    /// </summary>
    public class Reserver
	{
        [Column("id"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid id_reservation { get; set; }
        [Column("Utilisateur"), ForeignKey("id_utilisateur"), Required]
		public Guid id_utilisateur { get; set; }
        [Column("Session"), ForeignKey("id_session"), Required]
		public Guid id_session { get; set; }
        [Column("Participant"), Required]
		public int nb_participant {  get; set; }

        #region Liaison de models
        public Session? Session { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        #endregion
    }
}