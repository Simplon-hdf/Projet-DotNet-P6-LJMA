using Projet_DotNet_P6_LJMA.Data;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    public class UtilisateurRepository
    {
        private readonly ApiDbContext _context;

        /// <summary>
        /// La classe UtilisateurRepository est notre couche d'accès aux données 
        /// ( Data access Layer )
        /// et prend en paramètre le <c>context</c> de la base de donnée ( Data Storage )
        /// </summary>
        /// <param name="context"> </param>
        public UtilisateurRepository(ApiDbContext context)
        {
            _context = context;
        }
    }
}
