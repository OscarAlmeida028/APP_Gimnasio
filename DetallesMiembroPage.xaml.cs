

namespace APP_Gimnasio;

public partial class DetallesMiembroPage : ContentPage
{
    private readonly APIService _APIService;
    public DetallesMiembroPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string idMiembro = Preferences.Get("idMiembro", "0");
        string nombreMiembro = Preferences.Get("nombre", "0");
        string apellidoMiembro = Preferences.Get("apellido", "0");
        string correoMiembro = Preferences.Get("email", "0");
        string fecha = Preferences.Get("fechaInscripcion", "0");

        // Concatenar el nombre y apellido antes de asignar al label

        string nombreCompleto = $"{nombreMiembro} {apellidoMiembro}";

        idUsuario.Text = idMiembro;
        NombreMiembro.Text = nombreCompleto;
        Correo.Text = correoMiembro;
        Fecha.Text = fecha;
    }

    private async void OnClickCerrarSesion(object sender, EventArgs e)
    {
        Preferences.Set("username", "0");
        await Navigation.PushAsync(new LoginPage(_APIService));
    }

    private async void OnClicKCambiar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CambioContra(_APIService));
    }
}