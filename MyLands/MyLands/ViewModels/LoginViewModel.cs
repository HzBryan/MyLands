namespace MyLands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        //Inicialmente teniamos implementada la interfaz INotifyPropertyChanged aqui, pero para optimizar
        //el codigo, creamos la BaseViewModel y heredamos la interfaz de ahi y hacemos la referencia propia
        //para cada propiedad, para asi actualizar la vista
        public string Email
        {
            get { return this.email; }
            set { this.SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { this.SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        //Validacion del inicio de sesion
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Email",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Password",
                    "Accept");
                return;
            }

            this.IsRunning = true;  //Habilitamos la accion de "Se esta ejecutando" para darle mayor visibilidad al usuario
            this.IsEnabled = false; //Deshabilitamos los botones para que el usuario no pueda hacer nada

            if (this.Email != "obrzz@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true; //Habilitamos los botones para el usuario
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;
            }
            
            this.IsRunning = false;
            this.IsEnabled = true; //Habilitamos los botones para el usuario
            await Application.Current.MainPage.DisplayAlert(
                    "Ok",
                    "Good one",
                    "Accept");
            return;
        }

        public ICommand RegisterCommand
        {
            get;
            set;
        }
        #endregion 
    }
}
