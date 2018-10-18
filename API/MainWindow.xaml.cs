using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace API
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Get();
        }
        public async void Get()
        {
            // Vytvoření klienta
            HttpClient client = new HttpClient();
            // Odeslání dotazu na API + pamaretr pro výpis z kategorie dev
            var response = await client.GetAsync("https://www.reddit.com/r/memes.json");
            // Získání odpovědi v Json
            string json = await response.Content.ReadAsStringAsync();
            // Deserializace na dynamic objekt
            dynamic c = JsonConvert.DeserializeObject(json);
            // Vypsání z Dynamic
            string meme = c.data.children[5].data.url;
            System.IO.File.WriteAllText("path.txt", meme);

            MemImage.Source = new BitmapImage(new Uri(meme));
        }
    }
}
