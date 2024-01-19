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
    private async void validarLogin()
    {
        if (Preferences.Get("idMiembro", "0").Equals("0"))
        {
            await Navigation.PushAsync(new LoginPage(_APIService));
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        validarLogin();
        string username = Preferences.Get("email", "0");
        Username.Text = username;
        string idmiembro = Preferences.Get("idMiembro", "0");
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
        try
        {
            string idMiembro = Preferences.Get("idMiembro", "0");
            int.TryParse(idMiembro, out int id);

            Miembro miembro = await _APIService.GetMiembroByID(id);

            string idMembresia = Preferences.Get("idMembresia", "0");

            Membresia membresia = await _APIService.GetMembresiaByID(miembro.idMembresia);
            Preferences.Set("nombreMembresia", membresia.nombreMembresia);
            Preferences.Set("duracionMembresia", membresia.duracionMembresia.ToString());
            Preferences.Set("precioMembresia", membresia.precioMembresia.ToString());

            await Navigation.PushAsync(new DetallesMembresiaPage(_APIService));

        }catch (Exception ex) { }


    }

    private async void OnClikDetallesMiembro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMiembroPage(_APIService));
    }
}