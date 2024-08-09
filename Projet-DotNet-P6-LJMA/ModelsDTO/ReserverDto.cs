namespace Projet_DotNet_P6_LJMA.ModelsDTO;

public class ReserverDto
{
    public Guid reservationId { get; set; }
    public Guid utilisateurId { get; set; }
    public Guid sessionId { get; set; }
    public int participantNb { get; set; }
}