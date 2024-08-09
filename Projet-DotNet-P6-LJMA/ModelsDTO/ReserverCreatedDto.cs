using System.ComponentModel.DataAnnotations;

namespace Projet_DotNet_P6_LJMA.ModelsDTO;

public class ReserverCreatedDto
{
    public Guid utilisateurId { get; set; }
    public Guid sessionId { get; set; }
    public int participantNb { get; set; }
}
