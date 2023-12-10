using System.ComponentModel.DataAnnotations;

namespace APP_Gimnasio.Models
{
    public class Pago
    {
        [Key]
        public int idPago { get; set; }

        [Required]
        public int miembroId { get; set; }

        [Required]
        public DateTime fechaPago { get; set; }

        [Required]
        public double montoPago { get; set; }

        [Required]
        public string tipoTarjeta { get; set; }

        [Required]
        [MinLength(16, ErrorMessage = "El número de tarjeta debe tener al menos 16 dígitos!")]
        [MaxLength(19, ErrorMessage = "El número de tarjeta no puede tener más de 19 dígitos!")]
        public string numeroTarjeta { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "El número CVV no puede tener más de 4 dígitos!")]
        public string cvvTarjeta { get; set; }

        [Required]
        public DateTime caducidadTarjeta { get; set; }

        [Required]
        public string titularTarjeta { get; set; }
    }
}
