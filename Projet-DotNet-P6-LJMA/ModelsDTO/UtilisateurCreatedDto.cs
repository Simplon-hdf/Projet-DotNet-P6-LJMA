using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class UtilisateurCreatedDto : UtilisateurDto
    {
        [Required, MaxLength(255)]
        public string Password { get; set; }
    }
}
