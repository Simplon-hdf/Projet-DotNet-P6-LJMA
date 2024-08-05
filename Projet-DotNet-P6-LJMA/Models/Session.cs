using System.ComponentModel.DataAnnotations;

/// <summary>
/// SummCette classe représente l'entité Session de la BDD.
/// </summary>
public class Session
{
    [Key]
    [Required]
    public int id_session{ get; set; }

    [StringLength(50)]
    public string? nom_session { get; set; }

    [DataType(DataType.Date)]
    public DateTime? date_debut_session { get; set; }

    [DataType(DataType.Date)]
    public DateTime? date_fin_session { get; set; }
}
