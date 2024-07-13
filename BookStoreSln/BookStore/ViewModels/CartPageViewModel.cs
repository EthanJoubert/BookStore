using BookStore.Models;
using BookStore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        private ObservableCollection<Cart> _cartitems;
        public ObservableCollection<Cart> CartItems
        {
            get { return _cartitems; }
            set { _cartitems = value; OnPropertyChanged(); }
        }

        private BooksDatabase _bookdatabase;
        public CartPageViewModel(BooksDatabase database)
        {
            _bookdatabase = database;
            CartItems = new ObservableCollection<Cart>(_bookdatabase.GetCartItems());
        }
    }
}
