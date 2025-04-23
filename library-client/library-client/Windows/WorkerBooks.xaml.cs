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
    /// Логика взаимодействия для WorkerBooks.xaml
    /// </summary>
    public partial class WorkerBooks : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public WorkerBooks(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            api();
        }
        public async Task<List<Book>> FillBooks()
        {
            var response = await client.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            return books;
        }
        public async void api()
        {
            BooksDataGrid.ItemsSource = await FillBooks();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var books = await FillBooks();
            var search = books.Where(p => p.title == searchingTextBox.Text).ToList();
            BooksDataGrid.ItemsSource = search;
        }
    }
}
