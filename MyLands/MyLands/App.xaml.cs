namespace MyLands
{
    using Helpers;
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        #endregion

        #region Constructors
        public App ()
        {
            InitializeComponent ();

            if (string.IsNullOrEmpty(Settings.Token)) //Preguntamos si el token esta vacio, para saber si esta recordado en el celular
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else //Si no esta vacio, lo enviamos a la MasterPage
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token; //Asi recuperamos el Token que esta en persistencia
                mainViewModel.TokenType = Settings.TokenType; //Asi recuperamos el TokenType que esta en persistencia
                mainViewModel.Lands = new LandsViewModel(); //Antes de ir a MasterPage debemos enviarle la LandsViewModel para que cargue los paises
                Application.Current.MainPage = new MasterPage();
            }
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
