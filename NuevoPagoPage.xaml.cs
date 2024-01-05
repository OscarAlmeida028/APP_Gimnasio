using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using APP_Gimnasio.Models;
using CommunityToolkit.Maui.Core;

namespace APP_Gimnasio
{
    public partial class NuevoPagoPage : ContentPage
    {
        private readonly APIService _APIService;
        public ObservableCollection<string> OpcionesTarjetas { get; set; }

        public NuevoPagoPage(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;

            OpcionesTarjetas = new ObservableCollection<string>
            {
                "Discover",
                "MasterCard",
                "Visa"
            };

            TipoTarjeta.ItemsSource = OpcionesTarjetas;
        }

        private async void OnClickPagar(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los controles de la interfaz de usuario
                DateTime fechaActual = DateTime.Now; // Obtener la fecha y hora actual
                DateTime fechaYHoraSeleccionada = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, CaducidadHora.Time.Hours, CaducidadHora.Time.Minutes, CaducidadHora.Time.Seconds);
                DateTime fechaPago = fechaYHoraSeleccionada;

                double montoPago;

                if (!double.TryParse(Monto.Text, out montoPago) || montoPago <= 0)
                {
                    // Mostrar un Toast indicando que el monto no es válido
                    var toast = Toast.Make("Ingrese un monto válido y positivo", ToastDuration.Short, 14);
                    await toast.Show();
                    return;
                }

                string tipoTarjeta = TipoTarjeta.SelectedItem?.ToString(); // Obtener el valor seleccionado del Picker

                string numeroTarjeta = NumTarjeta.Text;
                string cvvTarjeta = CVV.Text;
                DateTime caducidadTarjeta = CaducidadFecha.Date;
                string titularTarjeta = Titular.Text;
                string idMiembro = Preferences.Get("idMiembro", "0");
                int.TryParse(idMiembro, out int id);

                // Validar que la fecha de pago no sea anterior a hoy
                if (fechaPago < DateTime.Today)
                {
                    // Mostrar un Toast indicando que la fecha de pago no es válida
                    var toast = Toast.Make("La fecha de pago no puede ser anterior a hoy", ToastDuration.Short, 14);
                    await toast.Show();
                    return;
                }

                // Validar que la fecha de caducidad no sea anterior a hoy
                if (caducidadTarjeta < DateTime.Today)
                {
                    // Mostrar un Toast indicando que la fecha de caducidad no es válida
                    var toast = Toast.Make("La fecha de caducidad no puede ser anterior a hoy", ToastDuration.Short, 14);
                    await toast.Show();
                    return;
                }

                // Construir el objeto de Pago
                Pago nuevoPago = new Pago
                {
                    miembroId = id,
                    fechaPago = fechaPago,
                    montoPago = montoPago,
                    tipoTarjeta = tipoTarjeta,
                    numeroTarjeta = numeroTarjeta,
                    cvvTarjeta = cvvTarjeta,
                    caducidadTarjeta = caducidadTarjeta,
                    titularTarjeta = titularTarjeta
                };

                // Llamar al servicio para realizar el pago
                await RealizarPago(nuevoPago);
            }
            catch (Exception ex)
            {
                // Mostrar un Toast indicando que ocurrió un error
                var toast = Toast.Make("Ocurrió un error al procesar el pago", ToastDuration.Short, 14);
                await toast.Show();
            }
        }

        private async Task RealizarPago(Pago nuevoPago)
        {
            // Llamar a tu servicio para realizar el pago
            await _APIService.CreatePago(nuevoPago);
            var toast = Toast.Make("Pago realizado", ToastDuration.Short, 14);
            await toast.Show();
            await Navigation.PushAsync(new HomePage(_APIService));

            // Manejar el resultado del pago según sea necesario
        }

        private async void OnClickRegresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage(_APIService));
        }
    }
}
