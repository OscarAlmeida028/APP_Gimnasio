using System.ComponentModel.DataAnnotations;

namespace APP_Gimnasio.Models
{
    public class Membresia
    {
        [Key]
        public int idMembresia { get; set; }

        [Required]
        public string nombreMembresia { get; set; }

        [Required]
        public int duracionMembresia { get; set; }

        [Required]
        public double precioMembresia { get; set; }
    }
}
