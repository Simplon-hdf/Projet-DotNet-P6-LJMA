using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class PostDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid Id { get; set; }
        [MaxLength(2000), Required]
        public string? Content { get; set; }
        [MaxLength(2000)]
        public string Image { get; set; }
    }
}
