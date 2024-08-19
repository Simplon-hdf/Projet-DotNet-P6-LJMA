using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class RandonneeDTO
    {
        public Guid Id { get; set; }
        public decimal Prix { get; set; }
        public string Desc { get; set; }
        [MaxLength(50)]
        public string Lieu { get; set; }
        [MaxLength(2000)]
        public string Image { get; set; }
        public int Nb_nuit { get; set; }
        public int Nb_jour { get; set; }
        public int Limite_participant { get; set; }
    }
}
