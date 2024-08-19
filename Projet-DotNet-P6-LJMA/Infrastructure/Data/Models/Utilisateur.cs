using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_DotNet_P6_LJMA.Shared.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Data.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        #region Propriétés d'identification
        [Column("id_utilisateur", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        #endregion

        #region Informations personnelles
        [Column("prenom_utilisateur"), MaxLength(40)]
        public string Prenom { get; set; }

        [Column("nom_utilisateur"), MaxLength(40)]
        public string Nom { get; set; }

        [Column("telephone_utilisateur"), MaxLength(20)]
        public string Telephone { get; set; }
        #endregion

        #region Informations d'authentification
        [Column("mot_de_passe_utilisateur"), MaxLength(100)]
        public string MotDePasse { get; set; }

        [Column("mail_utilisateur"), MaxLength(191)]
        [EmailAdress]
        public string Email { get; set; }

        [Column("role_utilisateur")]
        public string Role { get; set; }
        #endregion
    }
}