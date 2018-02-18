namespace MyLands.ViewModels
{
<<<<<<< HEAD
    using GalaSoft.MvvmLight.Command;
=======
>>>>>>> parent of 9481d84... Login Validation
    using System.Windows.Input;

<<<<<<< HEAD
    public class LoginViewModel : BaseViewModel
    {

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

=======
    public class LoginViewModel
    {

>>>>>>> parent of 9481d84... Login Validation
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
<<<<<<< HEAD
            get { return this.password; }
            set { this.SetValue(ref this.password, value); }
=======
            get;
            set;
>>>>>>> parent of 9481d84... Login Validation
        }

        public bool IsRunning
        {
<<<<<<< HEAD
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
=======
            get;
            set;
>>>>>>> parent of 9481d84... Login Validation
        }

        public bool IsRemembered
        {
            get;
            set;
        }
<<<<<<< HEAD

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
=======
>>>>>>> parent of 9481d84... Login Validation
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;

        }
        #endregion

        #region Commands
        //public ICommand LoginCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(Login)
        //    }
        //}

        //public ICommand RegisterCommand
        //{
        //    get;
        //    set;
        //}
        #endregion 
    }
}
