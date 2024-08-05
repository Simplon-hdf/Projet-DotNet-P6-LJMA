using System.ComponentModel.DataAnnotations;

/// <summary>
/// Cette classe représente l'entité Reserver de la BDD.
/// </summary>
namespace Projet_DotNet_P6_LJMA.Models
{
	public class Reserver
	{

		[Key]
		[Required]
		public int id_utillisateur { get; set; }
		public int id_session { get; set; }

	}
}
