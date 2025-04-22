using library_client.Models;
using System;
using System.Buffers.Text;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly User _user;
        private readonly HttpClient _client;
        private readonly string baseUrl;

        public UserWindow(User user,HttpClient client,string baseUrl)
        {
            InitializeComponent();
            _user = user;
            this._client = client;
            this.baseUrl = baseUrl;
            api();
            FillComboBoxes();
        }

        private async void api()
        {
            var n = await FillDataGrid();
            booksDataGrid.ItemsSource = n;
        }

        public async Task<List<Book>> FillDataGrid()
        {
            var response = await _client.GetAsync($"{baseUrl}/Book/{_user.id}");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            return books;
        }

        private void mycard_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new UserTicket(_user,_client,baseUrl);
            wnd.Show();
            this.Hide();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var books = await FillDataGrid();
            booksDataGrid.ItemsSource = books.Where(p => p.title.Contains(BookNameTextBox.Text));
        }
        public async void FillComboBoxes()
        {
            var response = await _client.GetAsync($"{baseUrl}/Author");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Author>>(content);

            var response1 = await _client.GetAsync($"{baseUrl}/Genre");
            var content1 = await response1.Content.ReadAsStringAsync();
            var books1 = JsonSerializer.Deserialize<List<Genre>>(content1);
            GenreComboBox.ItemsSource = books1;
            AuthorComboBox.ItemsSource = books;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            api();
            BookNameTextBox.Text = string.Empty;
            GenreComboBox.SelectedItem = null;
            AuthorComboBox.SelectedItem = null;
        }

        private async void AuthorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorComboBox.SelectedItem is null)
            {
                return; 
            }
            var books = await FillDataGrid();
            var bookss = books.Where(p => p.author == AuthorComboBox.SelectedValue.ToString()).ToList();
            booksDataGrid.ItemsSource = bookss;
        }

        private async void GenreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedItem is null)
            {
                return;
            }
            var books = await FillDataGrid();
            var bookss = books.Where(p => p.genre == GenreComboBox.SelectedValue.ToString()).ToList();
            booksDataGrid.ItemsSource = bookss;
        }
    }
}
