using System.ComponentModel.DataAnnotations;

namespace APP_Gimnasio.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
