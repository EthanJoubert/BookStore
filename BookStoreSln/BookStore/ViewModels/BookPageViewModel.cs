using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.ViewModels
{
    [QueryProperty(nameof(Book), "Book")]
    public partial class BookPageViewModel : BaseViewModel
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        private Book _book;
        public Book BookDetails
        {
            get { return _book; }
            set
            {
                _book = value;
                Books = new ObservableCollection<Book>();
                OnPropertyChanged();
            }
        }

        private readonly HttpClient _client;

        public BookPageViewModel()
        {
            _client = new HttpClient();
            Books = new ObservableCollection<Book>();
            GetBooks();
        }

        public async void GetBooks()
        {
            HttpResponseMessage response = await _client.GetAsync("https://api.itbook.store/1.0/new");
            response.EnsureSuccessStatusCode(); // Ensure success status code

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

            if (root.books != null && root.books.Count > 0)
            {
                Books.Clear();
                foreach (var book in root.books)
                {
                    Books.Add(book);
                }
            }
        }

        public void CurrentBookDetails()
        {
            BookTitle = BookDetails.title;
        }
    }
}
