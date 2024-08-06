using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Models
{
	/// <summary>
	/// Cette classe représente l'entité Vlog de la BDD.
	/// </summary>
	public class Vlog
	{
		[Key]
		[Required]
		public int id_vlog { get; set; }
		[Required]
		[StringLength(50)]
		public string? nom_video { get; set; }
		[Required]
		[StringLength(2000)]
		public string? url_video { get; set; }
		[Required]
		[StringLength(2000)]
		public string? desc_video { get; set; }
	}
}