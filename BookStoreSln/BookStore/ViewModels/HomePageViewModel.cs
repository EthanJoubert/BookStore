using BookStore.Models;
using BookStore.Services;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {

        private ObservableCollection<Book> _bookstodisplay;
        public ObservableCollection<Book> BooksToDisplay
        {
            get { return _bookstodisplay; }
            set { _bookstodisplay = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Book> _comingsoonbooks;
        public ObservableCollection<Book> ComingSoonBooks
        {
            get { return _comingsoonbooks; }
            set { _comingsoonbooks = value; OnPropertyChanged(); }
        }


        private HttpClient _client;
        private BooksDatabase _bookdatabase;

        public HomePageViewModel(BooksDatabase database) 
        {
            _client = new HttpClient();
            _bookdatabase = database;
            GetBooks();
            ComingSoonBooks = new ObservableCollection<Book>(_bookdatabase.GetComingSoonBooks());
        }
        

        [RelayCommand]
        public async void GetBooks()
        {

            HttpResponseMessage response = await _client.GetAsync("https://api.itbook.store/1.0/new");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                BooksToDisplay = new ObservableCollection<Book>(root.books);
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
                //BookName = root.books[0].title;

            }
        }



        [RelayCommand]
        public static async Task BookSelected(Book books)
        {
            var navigationParameter = new Dictionary<string, object>
           {
                { "Book", books }
           };
            await Shell.Current.GoToAsync($"book", navigationParameter);

        }
    }
}
