using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Get("get_persons.php");
            //PersonsList.ItemsSource = persons;
        }
        public async void Get(string url)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://student.sps-prosek.cz/~vancaja15/api/"+url);

            string json = await response.Content.ReadAsStringAsync();

            Response<Person> resObj = JsonConvert.DeserializeObject<Response<Person>>(json);

            PersonsList.ItemsSource = resObj.data;
        }
    }
}
