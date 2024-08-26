using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("vlog")]
    public class Vlog
    {
        #region Propriétés d'identification
        [Column("id_vlog", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VlogId { get; set; }
        #endregion

        #region Informations sur le vlog
        [Column("nom_video"), MaxLength(50)]
        public string NomVideo { get; set; }

        [Column("url_video"), MaxLength(2000)]
        public string UrlVideo { get; set; }

        [Column("desc_video"), MaxLength(2000)]
        public string DescVideo { get; set; }
        #endregion
    }
}