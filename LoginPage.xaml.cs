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
        
        Miembro miembro2 = await _APIService.LoginMiembro(miembro);
        if (miembro2 != null)
        {

            Preferences.Set("username", miembro2.emailMiembro);
            Preferences.Set("idmiembro", miembro2.idMiembro.ToString());

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

    private async void OnClickRegistro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroPage(_APIService));
    }
}