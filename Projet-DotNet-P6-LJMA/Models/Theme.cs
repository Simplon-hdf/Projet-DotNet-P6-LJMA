using System.ComponentModel.DataAnnotations;

/// <summary>
/// Cette classe représente l'entité Theme de la BDD.
/// </summary>
public class Theme
{
	[Key]
	[Required]
	public int Id_theme { get; set; }

	[StringLength(50)]
	public string? Nom_theme { get; set; }
}
