using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Riok.Mapperly.Abstractions;

namespace Projet_DotNet_P6_LJMA.Mapping
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public static partial class Mapper
    {
        public static partial UtilisateurDto MapToDto(this Utilisateur utilisateur);
        public static partial Utilisateur Map(this UtilisateurDto utilisateur);

        public static partial ReserverDto MapToDto(this Reserver reserver);
        public static partial Reserver Map(this ReserverDto reserver);
    }
}
