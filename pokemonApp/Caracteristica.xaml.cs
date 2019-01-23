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
    public partial class Caracteristica : ContentPage
    {
        public ApiServices DataService { get; } = new ApiServices();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();



        public Caracteristica()
        {
            InitializeComponent();
        }
        public Caracteristica(string id, string nombre)
        {
            InitializeComponent();
            encabezado.Source = ImageSource.FromResource("encabezado.png");
            encabezado.HeightRequest = 100;
            encabezado.WidthRequest = 150;

            Cargar("https://pokeapi.co/api/v2/pokemon/" + id, nombre);
        }

        private async void Cargar(string Url, string nombre)
        {


            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Imposible continuar", "No hay conexion a internet", "Continuar");
                return;
            }
            try
            {
                var data = await DataService.GetStringDAsync(Url);
                List<Habilidad> ListaD = new List<Habilidad>();
                List<Habilidad2> ListaH = new List<Habilidad2>();
                ListaD = data.Abilities.ToList();
                name.Text = nombre + " Habilidades";
                foreach (var item in ListaD)
                {
                    ListaH.Add(item.Ability);
                }

                ListViewHabilidad.ItemsSource = ListaH;


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

    }
}
