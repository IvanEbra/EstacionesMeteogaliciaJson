using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace PracticaJson4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Iniciar();
        }

        private async void Iniciar()
        {
            try
            {
                await CargarDatos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Json estaciones;
        String estacion;
        String provincia;

        public async Task CargarDatos()
        {
            HttpClient cliente = new HttpClient();
            String url = "http://servizos.meteogalicia.es/rss/observacion/listaEstacionsMeteo.action";
            Stream respuesta = await cliente.GetStreamAsync(url);
            StreamReader reader = new StreamReader(respuesta, Encoding.UTF8, false);
            estaciones = JsonConvert.DeserializeObject<Json>(reader.ReadToEnd());
            AñadirItems();
        }

        private void AñadirItems()
        {
            comboBoxEstaciones.ItemsSource = estaciones.listaEstacionsMeteo.Select(e => e.estacion).ToList();
            comboBoxProvincia.ItemsSource = estaciones.listaEstacionsMeteo.Select(e => e.provincia).Distinct().ToList();
        }

        private void comboBoxEstaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            estacion = comboBoxEstaciones.SelectedItem.ToString();
            dataGridEstacion.ItemsSource = estaciones.listaEstacionsMeteo.Where(c => c.estacion.Equals(estacion));
        }

        private void comboBoxProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            provincia = comboBoxProvincia.SelectedItem.ToString();
            dataGridEstacion.ItemsSource = estaciones.listaEstacionsMeteo.Where(c => c.provincia.Equals(provincia));
        }

    }
}
