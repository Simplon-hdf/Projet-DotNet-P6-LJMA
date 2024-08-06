using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet_P6_LJMA.Models
{
	/// <summary>
	/// Cette classe représente l'entité Theme de la BDD.
	/// </summary>
	public class Theme
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
		public Guid id_theme { get; set; }

		[StringLength(50)]
		public string? nom_theme { get; set; }
	}
}
