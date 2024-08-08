using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class ThemeDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50)]

        public string? Nom { get; set; }
        
    }
}
