using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace DemoClienteGraphQL
{
    public partial class MainPage : ContentPage
    {
        private const string url = "https://fb321f57f3ae.ngrok.io/graphql";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Lugares> _lugares;

        public MainPage()
        {
            InitializeComponent();

            MiLista.Scrolled += OnListViewScrolled;
        }

        private void OnListViewScrolled(object sender, ScrolledEventArgs e)
        {
            _ = consultaGraphQLLugarAsync();
        }

        protected override void OnAppearing()
        {
            _ = consultaGraphQLLugarAsync();
            base.OnAppearing();
        }

        private async Task consultaGraphQLLugarAsync()
        {

            var stringContent = new StringContent("{\"query\":\"{lugares {id,nombre,descripcion,website}}\",\"variables\":{},\"operationName\":null}", Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpResponse = await client.PostAsync(url, stringContent);

            var json = await httpResponse.Content.ReadAsStringAsync();

            Root lugar = JsonConvert.DeserializeObject<Root>(json);

            _lugares = new ObservableCollection<Lugares>(lugar.lugares);

            MiLista.EndRefresh();

            MiLista.ItemsSource = _lugares;
            //Console.WriteLine(lugar.lugares[0].nombre);
        }

        public class Lugares
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string direccion { get; set; }
            public string telefono { get; set; }
            public string website { get; set; }
        }

        public class Root
        {
            public List<Lugares> lugares { get; set; }
        }

    }
}
