using System.ComponentModel.DataAnnotations;

namespace APP_Gimnasio.Models
{
    public class Visita
    {
        [Key]
        public int idVisita {  get; set; }

        [Required]
        public DateTime fechaVisita {  get; set; }

        [Required]
        public int miembroId {  get; set; }

        public string descripcionVisita {  get; set; }
    }
}
