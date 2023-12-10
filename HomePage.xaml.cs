namespace APP_Gimnasio;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnClickHistorialPagos(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new HistorialPagoPage());
    }

    private async void OnClickHistorialVisitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialVisitasPage());
    }

    private async void OnClickDetallesMembresia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMembresiaPage());
    }

    private async void OnClikDetallesMiembro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetallesMiembroPage());
    }
}