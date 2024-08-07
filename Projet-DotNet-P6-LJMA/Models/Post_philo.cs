using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("post_philo")]
    public class Post_philo
    {
        [Column("id_post"),Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required, MaxLength(36)]
        public Guid id_post {  get; set; }
        [Column("content_post"), MaxLength(2000), Required]
        public string? content_post { get; set; }
        [Column("img_post"), MaxLength(2000)]
        public string img_post { get; set; }
    }
}
