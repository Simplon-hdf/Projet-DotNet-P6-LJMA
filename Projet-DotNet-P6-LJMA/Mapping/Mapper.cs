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

        public static partial PostDto MapToDto(this Post post);
        public static partial Post Map(this PostDto post);

        public static partial ReserverDto MapToDto(this Reserver reserver);
        public static partial Reserver Map(this ReserverDto reserverDto);
        public static partial Reserver Map(this ReserverCreatedDto reserverCreatedDto);

        public static partial RandonneeDto MapToDto(this Randonnee utilisateur);
        public static partial Randonnee Map(this RandonneeDto utilisateur);


        public static partial ThemeDto MapToDto(this Theme theme);
        public static partial Theme Map(this ThemeDto theme);

        public static partial SessionDto MapToDto(this Session session);
        public static partial Session Map(this SessionDto session);

        public static partial VlogDto MapToDo(this Vlog vlog);
        public static partial Vlog Map(this VlogDto vlogDto);
        public static partial Vlog Map(this VlogCreatedDto vlogCreatedDto);
    }
}
