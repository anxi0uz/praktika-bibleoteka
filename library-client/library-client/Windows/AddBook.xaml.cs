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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public AddBook(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            FillAuthorComboBox();
            FillGenresComboBox();
        }
        public async void FillAuthorComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/Author");
            var content = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<List<Author>>(content);
            authorsComboBox.ItemsSource = authors;
        }
        public async void FillGenresComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/Genre");
            var content = await response.Content.ReadAsStringAsync();
            var Genres = JsonSerializer.Deserialize<List<Genre>>(content);
            GenreComboBox.ItemsSource = Genres;
        }

        private async void CreateBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var book = new BookRequest(TitleTextBox.Text, (int)authorsComboBox.SelectedValue, YearTextBox.Text, (int)GenreComboBox.SelectedValue, Convert.ToDecimal(PriceTextBox.Text));
                var userJson = JsonSerializer.Serialize(book);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{baseUrl}/Book", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Книга добавлена!");
                }
                else
                {
                    MessageBox.Show("Произошла ошибка, книга не добавлена!");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Произошла ошибка! Какое то из полей неверного формата");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Произошла ошибка :{ex}, Книга не добавлена!");
            }
        }
    }
}
