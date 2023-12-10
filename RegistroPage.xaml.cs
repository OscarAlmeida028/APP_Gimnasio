using APP_Gimnasio.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace APP_Gimnasio;

public partial class RegistroPage : ContentPage
{
    private readonly APIService _APIService;
    private Usuario _usuario;
	public RegistroPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _usuario = BindingContext as Usuario;
        if ( _usuario != null ) 
        {
            UsuarioNuevo.Text = _usuario.username;
            PasswordNueva.Text = _usuario.password;
        }
    }
    private async void OnClickRegistro(object sender, EventArgs e)
    {
        if( _usuario != null ) 
        {
            _usuario.username = UsuarioNuevo.Text;
            _usuario.password = PasswordNueva.Text;
        }

        var toast = Toast.Make("Usuario Registrado", ToastDuration.Short, 14);
        await toast.Show();

        await Navigation.PopAsync();
    }

    private async void OnClickVolver(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}