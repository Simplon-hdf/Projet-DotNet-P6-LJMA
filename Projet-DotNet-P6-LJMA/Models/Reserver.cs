using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Reserver de la BDD.
    /// </summary>
    public class Reserver
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
		public Guid id_reservation { get; set; }
        [Required]
        [ForeignKey("Utilisateur")]
		public Guid id_utilisateur { get; set; }
		[Required]
		[ForeignKey("Session")]
		public Guid id_session { get; set; }
		public int nb_participant {  get; set; }

        #region Liaison de models
        public Session Session { get; set; }
        public Utilisateur Utilisateur { get; set; }
        #endregion
    }
}
