using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using pokemonApp.estructuras;
using pokemonApp.servicios;
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace pokemonApp
{
    public partial class MainPage : ContentPage
    {
        public ApiServices DataService { get; } = new ApiServices();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        public List<Resultado> listadoP;

        public MainPage()
        {
            BindingContext = this;
            IsBusy = false;



            NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();

            encabezado.Source = ImageSource.FromResource("encabezado.png");
            encabezado.HeightRequest = 100;
            encabezado.WidthRequest = 150;
            //Refrescar();

        }

        private async void Refrescar()
        {
            IsBusy = false;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Imposible continuar", "No hay conexion a internet", "Continuar");
                return;
            }
            try
            {
                var data = await DataService.GetStringAsync();

                List<Resultado> resutaldoOrdenado;
                resutaldoOrdenado = data.Results;
                resutaldoOrdenado = resutaldoOrdenado.OrderBy(x => x.Name).ToList();

                listadoP = resutaldoOrdenado;

                ListViewListado.ItemsSource = listadoP;

                

                //foreach (var item in listadoP)
                //{
                //   Items.Add(item);
                //}
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Continuar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListViewListado.ItemsSource = listadoP;
            }

            else
            {
                ListViewListado.ItemsSource = listadoP.Where(x => x.Name.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
            }
        }

        void ListViewListado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem;

            var item = selectedItem as Resultado;

            Navigation.PushAsync(
              new Detalle(item.Url)
             );
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            search_pokemon.Text = "";

            Refrescar();
        }


    }
}
