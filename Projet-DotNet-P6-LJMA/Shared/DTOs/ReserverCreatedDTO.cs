namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class ReserverCreatedDTO
    {
        public Guid UtilisateurId { get; set; }
        public Guid SessionId { get; set; }
        public int ParticipantNb { get; set; }
    }
}