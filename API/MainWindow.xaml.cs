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
        public async void PostPerson(string url, Person person)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://student.sps-prosek.cz/~vancaja15/api/"+url);

            // Data, která se přidají k POST dotazu -> klíč je typu string a data jsou typu string

            var keyValues = new List<KeyValuePair<string, string>>();

            keyValues.Add(new KeyValuePair<string, string>("first_name", person.first_name));
            keyValues.Add(new KeyValuePair<string, string>("last_name", person.last_name));
            keyValues.Add(new KeyValuePair<string, string>("note", person.note));

            // Přidání dat do dotazu
            request.Content = new FormUrlEncodedContent(keyValues);
            // Zaslání POST dotazu
            var response = await client.SendAsync(request);
            // Získání odpovědi
            string json = await response.Content.ReadAsStringAsync();

            Response<Person> resObj = JsonConvert.DeserializeObject<Response<Person>>(json);
        }

        private void Evidovat(object sender, RoutedEventArgs e)
        {
            Person person = new Person(FirstName.Text, LastName.Text, Note.Text);
            PostPerson("add_person.php", person);
        }
    }
}
