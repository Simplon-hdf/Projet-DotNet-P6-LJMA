using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("theme")]
    public class Theme
    {
        #region Propriétés d'identification
        [Column("id_theme", TypeName = "BINARY(16)"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        #endregion

        #region Informations sur le thème
        [Column("nom_theme"), MaxLength(50)]
        public string? Nom { get; set; }
        #endregion
    }
}