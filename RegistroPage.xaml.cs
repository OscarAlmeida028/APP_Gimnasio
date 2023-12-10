namespace APP_Gimnasio;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
	}

    private async void OnClickRegistro(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LoginPage());
    }

    private async void OnClickVolver(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}