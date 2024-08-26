using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class UtilisateurDTO
    {
        public Guid Id { get; set; }
        
        [MaxLength(40)]
        public string Prenom { get; set; }

        [MaxLength(40)]
        public string Nom { get; set; }

        [MaxLength(20)]
        public string Telephone { get; set; }
        
        [Required, MaxLength(320)]
        public string Email { get; set; }
        
        public string Role { get; set; }
    }
}