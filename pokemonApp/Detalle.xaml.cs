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
    public partial class Detalle : ContentPage
    {
        public ApiServices DataService { get; } = new ApiServices();

        double peso;
        double altura;

        public Command HabCommand { get; set; }

        string idPokemon;
        string nombrePokemon;

        public Detalle()
        {

            InitializeComponent();
        }
        public Detalle(string Url)
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;

            HabCommand = new Command(() => Llamar());
            InitializeComponent();
            encabezado.Source = ImageSource.FromResource("encabezado.png");
            encabezado.HeightRequest = 100;
            encabezado.WidthRequest = 150;
            Cargar(Url);




        }

        private async void Cargar(string Url)
        {


            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Imposible continuar", "No hay conexion a internet", "Continuar");
                return;
            }
            try
            {
                var data = await DataService.GetStringPAsync(Url);
                peso = Convert.ToDouble(data.Weight * 0.1);
                altura = Convert.ToDouble(data.Height * 0.1);

                name.Text = data.Name;
                height.Text = "Altura: " + altura.ToString() + " m";
                weight.Text = "Peso: " + peso.ToString() + " kg";
                idPokemon = data.Id.ToString();
                nombrePokemon = data.Name;
                front_default.Source = data.Sprite.Front_default;
                back_default.Source = data.Sprite.Back_default;



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

        private async void Llamar()
        {


            await Navigation.PushAsync(
              new Caracteristica(idPokemon, nombrePokemon)
             );
        }

    }
}
