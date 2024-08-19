using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }

        [MaxLength(75)]
        public string Title { get; set; }
        
        [MaxLength(2000)]
        public string Content { get; set; }

        [MaxLength(2000)]
        public string Image { get; set; }
    }
}
