using APP_Gimnasio.Models;

namespace APP_Gimnasio;

public partial class DetallesMembresiaPage : ContentPage
{

    private readonly APIService _APIService;

    public DetallesMembresiaPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;

	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        string TipoMembresia = Preferences.Get("nombreMembresia", "0");
        string DuracionMembresia = Preferences.Get("duracionMembresia", "0");
        string PrecioMembresia = Preferences.Get("precioMembresia", "0");
        
        tipo.Text = TipoMembresia;
        duracion.Text = DuracionMembresia;
        precio.Text = PrecioMembresia;

    }
}