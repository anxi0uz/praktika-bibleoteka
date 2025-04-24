using library_client.Enums;
using library_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Shapes;

namespace library_client.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerBookRelease.xaml
    /// </summary>
    public partial class WorkerBookRelease : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public WorkerBookRelease(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            api();
        }
        public async void api()
        {
            UserComboBox.ItemsSource = await GetUsers();
            BookComboBox.ItemsSource = await GetBooks();
        }
        public async Task<List<User>> GetUsers()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
            return response1;
        }
        public async Task<List<Book>> GetBooks()
        {
            var response = await client.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<Book>>(content);
            return users;
        }
        public async Task<List<Ticket>> GetTickets()
        {
            var response = await client.GetAsync($"{baseUrl}/Ticket");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<Ticket>>(content);
            return users;
        }

        private async void ReleaseBook_Click(object sender, RoutedEventArgs e)
        {
            var post = new TicketPost(Convert.ToInt32(UserComboBox.SelectedValue.ToString()), Convert.ToInt32(BookComboBox.SelectedValue.ToString()), DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString(), int.Parse(TicketNumber_.Text));
            var userJson = JsonSerializer.Serialize(post);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/Ticket", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Книга выдана!");
            }
        }
    }
}
