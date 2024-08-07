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
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
		public Guid id_vlog { get; set; }
		[Column("nom_video"), Required, MaxLength(50)]
		public string? nom_video { get; set; }
		[Column("url_video"), Required, MaxLength(2000)]
		public string? url_video { get; set; }
		[Column("desc_video"), Required, MaxLength(2000)]
		public string? desc_video { get; set; }
	}
}