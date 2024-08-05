using System.ComponentModel.DataAnnotations;

/// <summary>
/// Cette classe représente l'entité Randonnee de la BDD.
/// </summary>
namespace Projet_DotNet_P6_LJMA.Models
{
    public class Randonnee
    {
        [Key]
        [Required]
        public int id_rando { get; set; }
        [Required]
        public decimal prix_rando { get; set; }
        [Required]
        public string desc_rando { get; set; }
        [Required]
        [StringLength(50)]
        public string lieu_rando { get; set; }
        [Required]
        [StringLength(2000)]
        public string image_rando { get; set; }
        public int nb_nuit_rando { get; set; }
        [Required]
        public int nb_jour_rando { get; set; }
        [Required]
        public int limite_participant { get; set; }

    }
}
