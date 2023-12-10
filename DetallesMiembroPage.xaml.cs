namespace APP_Gimnasio;

public partial class DetallesMiembroPage : ContentPage
{
    private readonly APIService _APIService;
    public DetallesMiembroPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
	}

    private async void OnClickCerrarSesion(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginPage(_APIService));
    }
}