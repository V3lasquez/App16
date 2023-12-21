using App16.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App16
{
    public partial class MainPage : ContentPage
    {
        private const string BaseUrl = "https://airbnb-api-mu.vercel.app";

        // Declarar la colección placesList
        private ObservableCollection<Place> placesList = new ObservableCollection<Place>();

        public MainPage()
        {
            InitializeComponent();
            // Establecer el ItemsSource del ListView en placesList
            listView.ItemsSource = placesList;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                // Realizar la solicitud GET al servidor
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y deserializar la respuesta JSON
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    // Manejar errores
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void llamarAPI(object sender, EventArgs e)
        {
            try
            {
                var result = await GetAsync<ResponseBase>("airbnb");

                // Actualiza la lista de lugares en la vista
                placesList.Clear();
                foreach (var place in result.places)
                {
                    placesList.Add(place);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                DisplayAlert("Error", $"Error en la solicitud: {ex.Message}", "Aceptar");
            }
        }
    }
}
