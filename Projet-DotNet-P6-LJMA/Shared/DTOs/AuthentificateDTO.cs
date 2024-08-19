namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class AuthentificateDTO
    {
        public Guid Id { get; set; }
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
