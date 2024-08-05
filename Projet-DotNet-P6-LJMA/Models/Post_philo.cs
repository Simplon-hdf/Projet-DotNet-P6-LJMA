using System.ComponentModel.DataAnnotations;

/// <summary>
/// Cette classe représente l'entité Post_philo de la BDD.
/// </summary>
namespace Projet_DotNet_P6_LJMA.Models
{
    public class Post_philo
    {
        [Key]
        [Required]
        public int id_post {  get; set; }

        public string? content_post { get; set; }
    }
}
