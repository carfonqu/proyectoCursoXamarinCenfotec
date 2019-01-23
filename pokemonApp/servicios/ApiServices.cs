using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using pokemonApp.estructuras;
using Newtonsoft.Json;

namespace pokemonApp.servicios
{
    public class ApiServices
    {
        private const string WEB_SERVICE_URL = "https://pokeapi.co/api/v2/pokemon/?limit=1000";

        public async Task<Listado> GetStringAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync("");
                var data = JsonConvert.DeserializeObject<Listado>(response);
                Debug.WriteLine(
                    data
                );
                return data;
            };
        }

        public async Task<Pokemon> GetStringPAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync("");
                var data = JsonConvert.DeserializeObject<Pokemon>(response);
                Debug.WriteLine(
                    data
                );
                return data;
            };
        }

        public async Task<Habilidades> GetStringDAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync("");
                var data = JsonConvert.DeserializeObject<Habilidades>(response);
                Debug.WriteLine(
                    data
                );
                return data;
            };
        }

    }
}
