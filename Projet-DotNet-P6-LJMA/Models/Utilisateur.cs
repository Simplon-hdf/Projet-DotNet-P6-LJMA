using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Models
{
    public class Utilisateur
    {
        [Key]
        [Required]
        int id_utilisateur { get; set; }
        [StringLength(40)]
        string? prenom_utilisateur { get; set; }
        [StringLength(40)]
        string? nom_utilisateur { get; set; }
        [StringLength(20)]
        string? telephone_utilisateur { get; set; }
        [StringLength(255)]
        string? mot_de_passe_utilisateur { get; set; }
        [Required]
        [StringLength(320)]
        string mail_utilisateur {  get; set; }
    }
}
