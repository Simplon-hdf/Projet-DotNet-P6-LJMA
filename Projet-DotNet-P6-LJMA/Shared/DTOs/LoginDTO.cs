using System.ComponentModel.DataAnnotations;
using Projet_DotNet_P6_LJMA.Shared.Attributes;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Le email ne peut pas être vide!")]
        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(12, ErrorMessage = "Le mot de passe doit contenir 12 caractères minimum")]
        [Required(ErrorMessage = "Le mot de passe ne peut pas être vide!"), MaxLength(100)]
        [ComplexPassword]
        public required string MotDePasse { get; set; }
    }
}
