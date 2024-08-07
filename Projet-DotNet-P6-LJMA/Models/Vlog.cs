using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
	/// <summary>
	/// Cette classe représente l'entité Vlog de la BDD.
	/// </summary>
	[Table("Vlog")]
	public class Vlog
	{
		[Column("id"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid id_vlog { get; set; }
		[Column("nom_video"), Required, StringLength(50)]
		public string? nom_video { get; set; }
		[Column("url_video"), Required, StringLength(2000)]
		public string? url_video { get; set; }
		[Column("desc_video"), Required, StringLength(2000)]
		public string? desc_video { get; set; }
	}
}