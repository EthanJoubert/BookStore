using BookStore.Models;
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
    public partial class SearchPageViewModel : BaseViewModel
    {
        private ObservableCollection<Book> _bookstodisplay;
        public ObservableCollection<Book> BooksToDisplay
        {
            get { return _bookstodisplay; }
            set { _bookstodisplay = value; OnPropertyChanged(); }
        }

        private string _searchkey;

        public string SearchKey
        {
            get { return _searchkey; }
            set { _searchkey = value; OnPropertyChanged(); }
        }


        private HttpClient _client;
        public SearchPageViewModel()
        {
            _client = new HttpClient();
        }

        [RelayCommand]
        public async void SearchForBook()
        {
            //string searchkey = "programming";
            HttpResponseMessage response = await _client.GetAsync($"https://api.itbook.store/1.0/search/{SearchKey}");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                BooksToDisplay = new ObservableCollection<Book>(root.books);
            }
        }
    }
}
