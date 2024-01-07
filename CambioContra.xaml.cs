using APP_Gimnasio.Models;
using APP_Gimnasio.Models.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace APP_Gimnasio;

public partial class CambioContra : ContentPage
{
    private readonly APIService _APIService;

    public CambioContra(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }

    private async void OnClickCambiarContra(object sender, EventArgs e)
    {
        string contraActual = Password.Text;
        string contraNueva = PasswordNueva.Text;
            
        string idMiembro = Preferences.Get("idMiembro", "0");
        int.TryParse(idMiembro, out int id);

        if(contraActual != null || contraNueva != null)
        {
            // Cambio ViewModel
            Utils.Utils._viewModel.Miembro = await _APIService.GetMiembroByID(id);

            if (Utils.Utils._viewModel.Miembro.passwordMiembro.ToString() == contraActual)
            {
                Utils.Utils._viewModel.Miembro.passwordMiembro = contraNueva;
                Miembro miembroActualizado = await _APIService.UpdateMiembro(Utils.Utils._viewModel.Miembro, id);
                if (miembroActualizado != null)
                {
                    var toast = Toast.Make("Cambio exitoso", ToastDuration.Short, 14);
                    await toast.Show();
                    await Navigation.PopAsync();
                }
            }
            else
            {
                var toast = Toast.Make("Contraseña incorrecta", ToastDuration.Short, 14);
                await toast.Show();
            }

        }
        else
        {
            var toast = Toast.Make("Complete los campos", ToastDuration.Short, 14);
            await toast.Show();
        }


    }
}