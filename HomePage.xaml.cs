namespace APP_Gimnasio;

public partial class HomePage : ContentPage
{
    private readonly APIService _APIService;
    public HomePage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
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