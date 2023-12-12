using APP_Gimnasio.Models;
using System.Collections.ObjectModel;

namespace APP_Gimnasio;

public partial class HistorialVisitasPage : ContentPage
{
    private readonly APIService _APIService;
    ObservableCollection<Visita> visitas;
    public HistorialVisitasPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string idMiembro = Preferences.Get("idMiembro", "0");
        int.TryParse(idMiembro, out int id);
        List<Visita> ListaVisitas = await _APIService.GetVisitasPorMiembro(id);
        visitas = new ObservableCollection<Visita>(ListaVisitas);
        listaVisitas.ItemsSource = visitas;
        string correoMiembro = Preferences.Get("email", "0");
        correo.Text = correoMiembro;

    }
}