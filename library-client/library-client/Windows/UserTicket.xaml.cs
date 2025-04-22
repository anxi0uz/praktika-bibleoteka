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
    /// Логика взаимодействия для UserTicket.xaml
    /// </summary>
    public partial class UserTicket : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public UserTicket(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            api();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new UserWindow(user, client,baseUrl);
            wnd.Show();
            this.Hide();
        }
        private async void api()
        {
            var n = await FillDataGrid();
            booksDataGrid.ItemsSource = n;
        }

        public async Task<List<TicketRequest>> FillDataGrid()
        {
            var response = await client.GetAsync($"{baseUrl}/Ticket/{user.id}");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<TicketRequest>>(content);
            return books;
        }
    }
}
