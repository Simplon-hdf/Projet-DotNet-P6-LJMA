using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Models
{
	/// <summary>
	/// Cette classe représente l'entité Theme de la BDD.
	/// </summary>
	public class Theme
	{
		[Key]
		[Required]
		public int id_theme { get; set; }

		[StringLength(50)]
		public string? nom_theme { get; set; }
	}
}
