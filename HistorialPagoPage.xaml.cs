using APP_Gimnasio.Models;
using System.Collections.ObjectModel;
using APP_Gimnasio.Service;

namespace APP_Gimnasio;

public partial class HistorialPagoPage : ContentPage
{
    private readonly APIService _APIService;
    ObservableCollection<Pago> pagos;
    public HistorialPagoPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        base.OnAppearing();
        string idMiembro = Preferences.Get("idMiembro", "0");
        string correoMiembro = Preferences.Get("email", "0");
        correo.Text = correoMiembro;
        int.TryParse(idMiembro, out int id);
        List<Pago> ListaPagos = await _APIService.GetPagosPorMiembro(id);
        pagos = new ObservableCollection<Pago>(ListaPagos);
        listaPagos.ItemsSource = pagos;
    }
}