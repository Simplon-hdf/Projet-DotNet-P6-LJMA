using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class UtilisateurCreatedDTO
    {
        public string Prenom { get; set; }
        [MaxLength(40)]
        public string Nom { get; set; }
        [MaxLength(20)]
        public string Telephone { get; set; }
        [Required, MaxLength(320)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string MotDePasse { get; set; }
    }
}
