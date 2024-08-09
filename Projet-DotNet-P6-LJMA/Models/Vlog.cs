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
		public Guid vlogId { get; set; }
		[Column("nom_video"), Required, MaxLength(50)]
		public string? nomVideo { get; set; }
		[Column("url_video"), Required, MaxLength(2000)]
		public string? urlVideo { get; set; }
		[Column("desc_video"), Required, MaxLength(2000)]
		public string? descVideo { get; set; }
	}
}