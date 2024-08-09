using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
	[Table("Vlog")]
	public class Vlog
	{
		[Column("id_vlog"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid vlogId { get; set; }
		[Column("nom_video"), Required, MaxLength(50)]
		public string? nomVideo { get; set; }
		[Column("url_video"), Required, MaxLength(2000)]
		public string? urlVideo { get; set; }
		[Column("desc_video"), Required, MaxLength(2000)]
		public string? descVideo { get; set; }
	}
}