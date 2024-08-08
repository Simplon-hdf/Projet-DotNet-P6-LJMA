namespace Projet_DotNet_P6_LJMA.ModelsDTO;

public class ReserverDto
{
    public Guid id_reservation { get; set; }
    public Guid id_utilisateur { get; set; }
    public Guid id_session { get; set; }
    public int nb_participant { get; set; }
}