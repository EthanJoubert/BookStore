using BookStore.Models;
using BookStore.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public partial class CartPageViewModel : BaseViewModel
    {
        private ObservableCollection<Cart> _cartitems;
        public ObservableCollection<Cart> CartItems
        {
            get { return _cartitems; }
            set { _cartitems = value; OnPropertyChanged(); }
        }

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(); }
        }

        private BooksDatabase _bookdatabase;
        public CartPageViewModel(BooksDatabase database)
        {
            _bookdatabase = database;
            CartItems = new ObservableCollection<Cart>(_bookdatabase.GetCartItems());
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = _bookdatabase.GetTotalPrice();
        }

        public void RemoveFromCart(int itemId)
        {
            var item = CartItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _bookdatabase.RemoveFromCart(itemId);
                CartItems.Remove(item);
                CalculateTotalPrice();
            }
        }

        [RelayCommand]
        public async Task Checkout()
        {
            // Display the total price in an alert
            await Shell.Current.DisplayAlert("Checkout", $"Total Price: {TotalPrice:C}", "OK");
        }
    }
}
