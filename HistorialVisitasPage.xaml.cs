namespace APP_Gimnasio;

public partial class HistorialVisitasPage : ContentPage
{
    private readonly APIService _APIService;
    public HistorialVisitasPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}
}