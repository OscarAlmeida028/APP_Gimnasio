namespace APP_Gimnasio;

public partial class DetallesMiembroPage : ContentPage
{
	public DetallesMiembroPage()
	{
		InitializeComponent();
	}

    private async void OnClickCerrarSesion(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginPage());
    }
}