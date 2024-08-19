using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class SessionDTO
    {
        public Guid? Id { get; set; }
        [MaxLength(50)]
        public string? Nom { get; set; }
        public DateOnly Date_debut { get; set; }
        public DateOnly Date_fin { get; set; }
        public Guid RandonneeId { get; set; }
        public Guid ThemeId { get; set; }
    }
}
