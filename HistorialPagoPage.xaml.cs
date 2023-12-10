using APP_Gimnasio.Models;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class HistorialPagoPage : ContentPage
{
    private readonly APIService _APIService;
    ObservableCollection<Visita> visitas;
    public HistorialPagoPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Visita> listaVisitas = await _APIService.GetVisitas();
        visitas = new ObservableCollection<Visita>(listaVisitas);
        //listaVisitas.ItemsSource = visitas;

    }
}