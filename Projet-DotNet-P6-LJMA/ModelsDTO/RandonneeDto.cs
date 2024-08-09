using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO
{
    public class RandonneeDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Required, MaxLength(36)]
        public Guid Id { get; set; }
        [Required]
        public decimal Prix { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required, MaxLength(50)]
        public string Lieu { get; set; }
        [Required, MaxLength(2000)]
        public string Image { get; set; }
        public int Nb_nuit { get; set; }
        [Required]
        public int Nb_jour { get; set; }
        [Required]
        public int Limite_participant { get; set; }
    }
}
