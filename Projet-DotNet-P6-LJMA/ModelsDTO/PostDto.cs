using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class PostDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Required, MaxLength(36)]
        public Guid id_post { get; set; }
        [MaxLength(2000), Required]
        public string? content_post { get; set; }
        [MaxLength(2000)]
        public string img_post { get; set; }
    }
}
