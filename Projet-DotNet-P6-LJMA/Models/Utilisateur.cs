using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Column("id_utilisateur"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("prenom_utilisateur"), MaxLength(40)]
        public string? Prenom { get; set; }
        [Column("nom_utilisateur"), MaxLength(40)]
        public string? Nom { get; set; }
        [Column("telephone_utilisateur"), MaxLength(20)]
        public string? Telephone { get; set; }
        [Column("mot_de_passe_utilisateur"), MaxLength(255)]
        public string? Password { get; set; }
        [Column("mail_utilisateur"), Required, MaxLength(320)]
        public string Mail {  get; set; }
    }
}
