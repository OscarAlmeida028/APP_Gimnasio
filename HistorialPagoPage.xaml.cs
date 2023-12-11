using APP_Gimnasio.Models;
using System.Collections.ObjectModel;
using APP_Gimnasio.Service;

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
        List<Visita> ListaVisitas = await _APIService.GetVisitas();
        visitas = new ObservableCollection<Visita>(ListaVisitas);
        listaVisitas.ItemsSource = visitas;
    }
}