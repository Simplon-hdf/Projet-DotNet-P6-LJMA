using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Randonnee de la BDD.
    /// </summary>
    public class Randonnee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid id_rando { get; set; }
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
