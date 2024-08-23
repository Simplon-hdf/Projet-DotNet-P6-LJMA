using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("post")]
    public class Post
    {
        #region Propriétés d'identification
        [Column("id_post", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        #endregion

        #region Informations sur le post
        [Column("titre_post"), MaxLength(75)]
        public string Title { get; set; }

        [Column("contenu_post"), MaxLength(2000)]
        public string Content { get; set; }

        [Column("img_post"), MaxLength(2000)]
        public string Image { get; set; }
        #endregion
    }
}
