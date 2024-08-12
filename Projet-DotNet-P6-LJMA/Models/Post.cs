using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("post")]
    public class Post
    {
        [Column("id_post", TypeName = "BINARY(16)") ,Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid Id {  get; set; }
        [Column("content_post"), MaxLength(2000), Required]
        public string? Content{ get; set; }
        [Column("img_post"), MaxLength(2000)]
        public string Image { get; set; }
    }
}
