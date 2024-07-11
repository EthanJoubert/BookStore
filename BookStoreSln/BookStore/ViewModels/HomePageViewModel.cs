using BookStore.Models;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private string _bookname;

        public string BookName
        {
            get { return _bookname; }
            set { _bookname = value; OnPropertyChanged(); }
        }

        private HttpClient _client;

        public HomePageViewModel() 
        {
            _client = new HttpClient();
        }


        [RelayCommand]
        public async void GetBooks()
        {
            //List<Book> books = new List<Book>();

            HttpResponseMessage response = await _client.GetAsync("https://api.itbook.store/1.0/new");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                // Access the title of the first book
                BookName = root.books[0].title;
            }
        }

        [RelayCommand]
        public async void SearchForBook()
        {
            string searchkey = "programming";
            HttpResponseMessage response = await _client.GetAsync($"https://api.itbook.store/1.0/search/{searchkey}");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                BookName = root.books[0].title;

            }
        }

        [RelayCommand]
        public async void GetBookDetails()
        {
            string searchkey = "9781617294136";
            HttpResponseMessage response = await _client.GetAsync($"https://api.itbook.store/1.0/search/{searchkey}");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                BookName = root.books[0].title;

            }
        }
    }
}
