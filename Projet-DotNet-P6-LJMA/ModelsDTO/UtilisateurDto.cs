using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class UtilisateurDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(40)]
        public string? Prenom { get; set; }
        [MaxLength(40)]
        public string? Nom { get; set; }
        [MaxLength(20)]
        public string? Telephone { get; set; }
        [MaxLength(255)]
        public string? Password { get; set; }
        [Required, MaxLength(320)]
        public string Mail { get; set; }
    }
}
