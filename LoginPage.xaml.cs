namespace APP_Gimnasio;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnClickLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }

    private async void OnClickRegistro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroPage());
    }
}