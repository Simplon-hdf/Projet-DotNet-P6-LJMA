using System.ComponentModel.DataAnnotations;
using Projet_DotNet_P6_LJMA.Shared.Attributes;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class RegisterDTO
    {
        [MaxLength(40)]
        public string Prenom { get; set; }

        [MaxLength(40)]
        public string Nom { get; set; }

        [MaxLength(20)]
        public string Telephone { get; set; }

        [MaxLength(255, ErrorMessage = "Le mot de passe doit contenir 255 caractères maximum")]
        [MinLength(12, ErrorMessage = "Le mot de passe doit contenir 12 caractères minimum")]
        //[StringLength(255, MinimumLength = 12, ErrorMessage = "Le mot de passe doit contenir entre 12 et 255 caractères")]
        [ComplexPassword]
        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string MotDePasse { get; set; }

        [EmailAdress]
        public string Email { get; set; }
    }
}
