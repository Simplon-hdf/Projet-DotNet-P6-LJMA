using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class SessionDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string? Nom { get; set; }
        public DateOnly Date_debut { get; set; }
        public DateOnly Date_fin { get; set; }
        [Required]
        public Guid Id_rando { get; set; }
        [Required]
        public Guid Id_theme { get; set; }
    }
}
