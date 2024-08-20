namespace Projet_DotNet_P6_LJMA.Shared.DTOs
{
    public class ReserverDTO
    {
        public Guid ReservationId { get; set; }
        public Guid UtilisateurId { get; set; }
        public Guid SessionId { get; set; }
        public int ParticipantNb { get; set; }
    }
}