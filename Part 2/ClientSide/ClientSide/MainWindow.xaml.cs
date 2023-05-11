using ClientSide.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Window = System.Windows.Window;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://localhost:7028/api/";

        public MainWindow()
        {
            InitializeComponent();
            
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7028/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/member/getVaccinesById/" + IdTextBox.Text).Result;
                if (response.IsSuccessStatusCode)
                {
                    var vacs = response.Content.ReadFromJsonAsync<IEnumerable<Vaccine>>().Result;
                    vaccinesList.ItemsSource = vacs;
                }
                else
                {
                    MessageBox.Show("Failed to show vacs: " + response.ReasonPhrase);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error show vacs: " + ex.Message);
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7028/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/member/" + IdTextBox.Text).Result;
                if (response.IsSuccessStatusCode)
                {
                    var member = response.Content.ReadFromJsonAsync<Member>().Result;
                    memberDetails.DataContext = member;
                }
                else
                {
                    MessageBox.Show("Failed to show member: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error show member: " + ex.Message);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            try
            {
                // Initialize a new Vaccine object with data from the textboxes and datepicker

                Member member = new Member
                {
                    Id = int.Parse(Id.Text),
                    Name = Name.Text,
                    Address = Address.Text,
                    Birthday = Birthday.SelectedDate.Value,
                    Telephone = Telephone.Text,
                    Mobile = Mobile.Text,
                    PositiveAnswerDate = PositiveAnswerDate.SelectedDate.Value,
                    RecoveryDate = RecoveryDate.SelectedDate.Value

                };
                // Convert the Vaccine object to JSON using the Newtonsoft.Json library
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(member);

                // Create a new HttpClient object
                HttpClient client = new HttpClient();

                // Set the base URL for the API endpoint
                client.BaseAddress = new Uri("https://localhost:7028/");

                // Add a content-type header to the request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new StringContent object with the JSON data
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint and wait for a response
                HttpResponseMessage response = client.PostAsync("api/member/", content).Result;

                // If the response status code indicates success, show a message box
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("member added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add member: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding member: " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize a new Vaccine object with data from the textboxes and datepicker
                Vaccine vaccine = new Vaccine
                {
                    Id = int.Parse(IdVac.Text),
                    VaccinationDate = VaccinationDate.SelectedDate.Value,
                    Producer = Producer.Text
                };

                // Convert the Vaccine object to JSON using the Newtonsoft.Json library
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(vaccine);

                // Create a new HttpClient object
                HttpClient client = new HttpClient();

                // Set the base URL for the API endpoint
                client.BaseAddress = new Uri("https://localhost:7028/");

                // Add a content-type header to the request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new StringContent object with the JSON data
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint and wait for a response
                HttpResponseMessage response =  client.PostAsync("api/member/AddVaccine", content).Result;

                // If the response status code indicates success, show a message box
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Vaccination added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add vaccination: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding vaccination: " + ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7028/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/member").Result;
                if (response.IsSuccessStatusCode)
                {
                    var members = response.Content.ReadFromJsonAsync<IEnumerable<Member>>().Result;
                    membersList.ItemsSource = members;
                }
                else
                {
                    MessageBox.Show("Failed to show members: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error show members: " + ex.Message);
            }

        }
    }
    
}
