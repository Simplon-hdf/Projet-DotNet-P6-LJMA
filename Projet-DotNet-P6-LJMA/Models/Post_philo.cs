using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projet_DotNet_P6_LJMA.Models
{
    /// <summary>
    /// Cette classe représente l'entité Post_philo de la BDD.
    /// </summary>
    public class Post_philo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid id_post {  get; set; }

        public string? content_post { get; set; }
    }
}
