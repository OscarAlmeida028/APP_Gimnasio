namespace APP_Gimnasio;

public partial class DetallesMembresiaPage : ContentPage
{
    private readonly APIService _APIService;
    public DetallesMembresiaPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}
}