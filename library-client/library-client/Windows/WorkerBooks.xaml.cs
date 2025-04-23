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
            FillYearsComboBox();
            FillAuthorComboBox();
            FillGenresComboBox();
        }
        public async Task<List<Book>> FillBooks()
        {
            var response = await client.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            return books;
        }
        public async void FillYearsComboBox()
        {
            var books = await FillBooks();
            var years = books.Select(s=>s.publishDate).ToList();
            YearsComboBox.ItemsSource = years;
        }
        public async void FillAuthorComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/Author");
            var content = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<List<Author>>(content);
            AuthorsComboBox.ItemsSource = authors;
        }
        public async void FillGenresComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/Genre");
            var content = await response.Content.ReadAsStringAsync();
            var Genres = JsonSerializer.Deserialize<List<Genre>>(content);
            GenreComboBox.ItemsSource = Genres;
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

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AddBook(user,client,baseUrl);
            wnd.Show();
        }

        private async void YearsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearsComboBox.SelectedItem == null) return;
            var books = await FillBooks();
            BooksDataGrid.ItemsSource = books.Where(p=>p.publishDate==YearsComboBox.SelectedItem.ToString()).ToList();
        }

        private async void AuthorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorsComboBox.SelectedItem == null) return;
            var books = await FillBooks();
            BooksDataGrid.ItemsSource = books.Where(p => p.author == AuthorsComboBox.SelectedValue.ToString()).ToList();
        }

        private async void GenreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedItem == null) return;
            var books = await FillBooks();
            BooksDataGrid.ItemsSource = books.Where(p => p.genre == GenreComboBox.SelectedValue.ToString()).ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            api();
            FillAuthorComboBox();
            FillGenresComboBox();
            FillYearsComboBox();
            GenreComboBox.SelectedItem = null;
            AuthorsComboBox.SelectedItem = null;
            YearsComboBox.SelectedItem = null;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new WorkerWindow(user,client,baseUrl);
            wnd.Show();
            this.Close();
        }
    }
}
