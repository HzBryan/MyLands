namespace MyLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models; 
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private List<Land> landsList;
        //private ObservableCollection<Land> lands;
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        //public ObservableCollection<Land> Lands
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { this.SetValue(ref this.lands, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.SetValue(ref this.filter, value);
                this.Search(); //Ejecutamos la busqueda instantaneamente se escribe algo en la barra de busqueda
                                //sin necesidad de darle buscar
            }
        }
        #endregion
        
        #region Constructors
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                //Si no hay conecxion devolvemos la aplicacion a la pagina anterior
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            //Obtiene la lista del modelo Land, que devuelve todos los paises 
            //Es necesario que tenga el await, porque al ser asyn el metodo continua 
            //ejecutandose y puede traer resultados no esperados
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all"); //Cada una de estas lineas son parametros de
                            //una sobrecarga de GetList<T>

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            //Inicialmente era una vble local pero lo cambiamos a una propiedad de la clase (global)
            //para facilitar el proceso de busqueda, ya que la vamos consultar varias veces
            //y es necesario mantenerla en memoria.
            //var list = (List<Land>)response.Result;
            this.landsList = (List<Land>)response.Result;                
            this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel());    //Antes se cargaba asi la Lista this.Lands = new ObservableCollection<Land>(this.landsList);
            this.IsRefreshing = false;                  //pero al implementar <LandItemViewModel> fue necesario crear un metodo para llenar la nueva Lista
        }
        #endregion

        #region Methods1
        private List<LandItemViewModel> ToLandItemViewModel()
        {
            //Con esta instruccion decimos que de landsList seleccione todo y cree un nuevo LandItemViewModel
            return this.landsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            }).ToList();
        }
        #endregion

        #region Commands
        //Los Comandos son propiedades de solo lectura
        public ICommand RefreshCommand
        {
            get
            {
                //Al hacer el Refresh volvemos a cargar los paises que ya esta implementado en LoadLands()
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                //Si el filtro esta vacio, trae toda la lista original
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel());  //this.Lands = new ObservableCollection<Land>(
            }                                       // this.landsList); Antes de implementar <LandItemViewModel>
            else
            {
                //Si esta lleno el filtro, cargamos lista pero con una estructura Linq decimos que queremos
                this.Lands = new ObservableCollection<LandItemViewModel>(   //this.Lands = new ObservableCollection<Land>(
                    this.ToLandItemViewModel().Where(                           // this.landsList.Where(;   Antes de implementar <LandItemViewModel>
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

    }
}
