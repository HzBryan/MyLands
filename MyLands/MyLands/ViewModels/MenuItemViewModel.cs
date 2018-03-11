﻿namespace MyLands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            if (this.PageName == "LoginPage")
            {
                Settings.Token = string.Empty; //Cuando el usuario cierre sesion, limpiamos la persistencia
                Settings.TokenType = string.Empty; //Cuando el usuario cierre sesion, limpiamos la persistencia

                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
        }
        #endregion
    }
}
