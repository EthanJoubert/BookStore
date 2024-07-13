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
    [QueryProperty(nameof(BookDetails), "Book")]
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
            //    if (_book != null)
            //    {
            //        GetBookDetails();
            //    }
            }
        }

        private ExtraBookDetails _bookdetails;
        public ExtraBookDetails BookDetailsAgain
        {
            get { return _bookdetails; }
            set
            {
                _bookdetails = value;
                //Books = new ObservableCollection<Book>();
                OnPropertyChanged();
                //if (_book != null)
                //{
                //    GetBookDetails();
                //}
            }
        }

        private readonly HttpClient _client;

        public BookPageViewModel()
        {
            _client = new HttpClient();
            Books = new ObservableCollection<Book>();
            GetBooks();
            // GetBookDetails();
        }

        public async void GetBooks()
        {
            HttpResponseMessage response = await _client.GetAsync("https://api.itbook.store/1.0/new");
            response.EnsureSuccessStatusCode();

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

        //public async void GetBookDetails()
        //{
        //    if (BookDetails == null || string.IsNullOrEmpty(BookDetails.isbn13))
        //        return;

        //    string searchKey = BookDetails.isbn13;
        //    HttpResponseMessage response = await _client.GetAsync($"https://api.itbook.store/1.0/books/{searchKey}");
        //    response.EnsureSuccessStatusCode();

        //    string jsonResponse = await response.Content.ReadAsStringAsync();
        //    ExtraBookDetails book = JsonConvert.DeserializeObject<ExtraBookDetails>(jsonResponse);

        //    if (book != null)
        //    {
        //        BookDetailsAgain = book;
        //    }
        //}
    }
}
