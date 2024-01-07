using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using APP_Gimnasio.Models;

namespace APP_Gimnasio;

public partial class LoginPage : ContentPage
{
    private readonly APIService _APIService;

    public LoginPage(APIService apiservice)
	{
        InitializeComponent();
        _APIService = apiservice;
    }

    private async void OnClickLogin(object sender, EventArgs e)
    { 
        string username = Username.Text;
        string password = Password.Text;

        Miembro miembro = new Miembro
        {
            emailMiembro = username,
            passwordMiembro = password,
        };
        
        Utils.Utils._viewModel.Miembro = await _APIService.LoginMiembro(miembro);
        if (Utils.Utils._viewModel.Miembro != null)
        { 
            Preferences.Set("idMiembro", Utils.Utils._viewModel.Miembro.idMiembro.ToString());
            Preferences.Set("idMembresia", Utils.Utils._viewModel.Miembro.idMembresia.ToString());
            Preferences.Set("nombre", Utils.Utils._viewModel.Miembro.nombreMiembro);
            Preferences.Set("apellido", Utils.Utils._viewModel.Miembro.apellidoMiembro);
            Preferences.Set("email", Utils.Utils._viewModel.Miembro.emailMiembro);
            Preferences.Set("fechaInscripcion", Utils.Utils._viewModel.Miembro.fechaInscripcion.ToString());

            var toast = Toast.Make("Ingreso Correcto", ToastDuration.Short, 14);
            await toast.Show();

            await Navigation.PushAsync(new HomePage(_APIService));
        }
        else
        {
            var toast = Toast.Make("Nombre de usuario o password incorrecto", ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}