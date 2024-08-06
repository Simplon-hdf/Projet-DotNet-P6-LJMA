using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// La Classe Utilisateur est l'entité Utilisateur de ma base de données
    /// </summary>
    public class Utilisateur
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_utilisateur { get; set; }
        [StringLength(40)]
        public string? prenom_utilisateur { get; set; }
        [StringLength(40)]
        public string? nom_utilisateur { get; set; }
        [StringLength(20)]
        public string? telephone_utilisateur { get; set; }
        [StringLength(255)]
        public string? mot_de_passe_utilisateur { get; set; }
        [Required]
        [StringLength(320)]
        public string mail_utilisateur {  get; set; }
    }
}
