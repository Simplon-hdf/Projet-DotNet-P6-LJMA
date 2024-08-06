using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// SummCette classe représente l'entité Session de la BDD.
    /// </summary>
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid id_session{ get; set; }

        [StringLength(50)]
        public string? nom_session { get; set; }

        [DataType(DataType.Date)]
        public DateTime? date_debut_session { get; set; }

        [DataType(DataType.Date)]
        public DateTime? date_fin_session { get; set; }

        [ForeignKey("Randonnee")]
        public Guid id_rando { get; set; }
        [ForeignKey("Theme")]
        public Guid id_theme { get; set; }

        #region Liaison de models
        public Randonnee Randonnee { get; set; }
        public Theme Theme { get; set; }
        #endregion
    }
}
