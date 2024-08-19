using Riok.Mapperly.Abstractions;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Shared.Mapping
{
    /// <summary>
    /// Classe de mappage responsable du mappage entre les modèles de domaine et les DTOs.
    /// </summary>
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public static partial class Mapper
    {
        public static partial LoginDTO MapToLoginDTO(this Utilisateur utilisateur);
        public static partial AuthentificateDTO MapToAuthentificateDTO(this Utilisateur utilisateur);

        #region Mappage Utilisateur
        public static partial UtilisateurDTO Map(this Utilisateur utilisateur);
        public static partial Utilisateur Map(this UtilisateurDTO utilisateur);
        public static partial Utilisateur Map(this UtilisateurCreatedDTO utilisateur);
        public static partial Utilisateur Map(this LoginDTO utilisateur);
        public static partial Utilisateur Map(this RegisterDTO utilisateur);
        #endregion

        #region Mappage Post
        public static partial PostDTO Map(this Post post);
        public static partial Post Map(this PostDTO post);
        #endregion

        #region Mappage Reserver
        public static partial ReserverDTO Map(this Reserver reserver);
        public static partial Reserver Map(this ReserverDTO reserverDto);
        public static partial Reserver Map(this ReserverCreatedDTO reserverCreatedDto);
        #endregion

        #region Mappage Randonnee
        public static partial RandonneeDTO Map(this Randonnee utilisateur);
        public static partial Randonnee Map(this RandonneeDTO utilisateur);
        #endregion

        #region Mappage Theme
        public static partial ThemeDTO Map(this Theme theme);
        public static partial Theme Map(this ThemeDTO theme);
        #endregion

        #region Mappage Session
        public static partial SessionDTO Map(this Session session);
        public static partial Session Map(this SessionDTO session);
        #endregion

        #region Mappage Vlog
        public static partial VlogDTO Map(this Vlog vlog);
        public static partial Vlog Map(this VlogDTO vlogDto);
        public static partial Vlog Map(this VlogCreatedDTO vlogCreatedDto);
        #endregion
    }
}