using APP_Gimnasio.Models;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class HomePage : ContentPage
{
    private readonly APIService _APIService;
    public HomePage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        Username.Text = username;
        string idmiembro = Preferences.Get("idmiembro", "0");
        idMiembro.Text = idmiembro;
    }
private async void OnClickHistorialPagos(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new HistorialPagoPage(_APIService));
    }

    private async void OnClickHistorialVisitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialVisitasPage(_APIService));
    }

    private async void OnClickDetallesMembresia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMembresiaPage(_APIService));
    }

    private async void OnClikDetallesMiembro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMiembroPage(_APIService));
    }
}