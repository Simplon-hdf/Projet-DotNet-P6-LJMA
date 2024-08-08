using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
    [Table("theme")]
    public class Theme
	{
        [Column("id_theme"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("nom_theme"), MaxLength(50)]
        public string? Nom { get; set; }
	}
}
