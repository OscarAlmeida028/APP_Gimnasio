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

            Utils.Utils._viewModel.Miembro = await _APIService.GetMiembroByID(id);

            // ViewModel
            Utils.Utils._viewModel.Membresia = await _APIService.GetMembresiaByID(Utils.Utils._viewModel.Miembro.idMembresia);
            Preferences.Set("nombreMembresia", Utils.Utils._viewModel.Membresia.nombreMembresia);
            Preferences.Set("duracionMembresia", Utils.Utils._viewModel.Membresia.duracionMembresia.ToString());
            Preferences.Set("precioMembresia", Utils.Utils._viewModel.Membresia.precioMembresia.ToString());

            await Navigation.PushAsync(new DetallesMembresiaPage(_APIService));

        }catch (Exception ex) { }


    }

    private async void OnClikDetallesMiembro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMiembroPage(_APIService));
    }
}