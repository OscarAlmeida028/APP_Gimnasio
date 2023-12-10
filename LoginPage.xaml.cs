using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

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
        var toast = Toast.Make("Ingreso Correcto", ToastDuration.Short, 14);

        await toast.Show();

        await Navigation.PushAsync(new HomePage(_APIService));
    }

    private async void OnClickRegistro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroPage(_APIService));
    }
}