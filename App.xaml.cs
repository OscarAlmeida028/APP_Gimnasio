using APP_Gimnasio.Models;

namespace APP_Gimnasio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiservice = new APIService();
            MainPage = new NavigationPage(new HomePage(apiservice));
        }
    }
}
