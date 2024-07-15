using BookStore.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BooksDatabase
    {
        private SQLiteConnection _dbConnection;

        public BooksDatabase()
        {
            _dbConnection = new SQLiteConnection(GetDatabasePath());
            _dbConnection.CreateTable<Book>();
            _dbConnection.CreateTable<Cart>();
            SeedDatabase();
        }
        public string GetDatabasePath()
        {
            string fileName = "profiledatabase.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return pathToDb + fileName;
        }
        public void SeedDatabase()
        {
            if (_dbConnection.Table<Book>().Count() == 0)
            {
                Book book1 = new Book()
                {
                    title = "Title",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book1);

                Book book2 = new Book()
                {
                    title = "Title 2",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book2);

                Book book3 = new Book()
                {
                    title = "Title 3",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book3);

                Book book4 = new Book()
                {
                    title = "Title 4",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book4);

                Book book5 = new Book()
                {
                    title = "Title 5",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book5);

                Book book6 = new Book()
                {
                    title = "Title 6",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(book6);
            }


            // Cart
            if (_dbConnection.Table<Cart>().Count() == 0)
            {
                Cart cart = new Cart()
                {
                    title = "Title 6",
                    image = "dotnet_bot.png",
                    price = "R 100"
                };
                _dbConnection.Insert(cart);
            }
        }

        // Methods
        public List<Book> GetComingSoonBooks()
        {
            return _dbConnection.Table<Book>().ToList();
        }


        // Cart Methods
        public void AddToCart(Book book)
        {
            Cart cartItem = new Cart()
            {
                title = book.title,
                image = book.image,
                price = book.price,
            };
            _dbConnection.Insert(cartItem);
            _cartItems.Add(cartItem);
        }

        private List<Cart> _cartItems = new List<Cart>();
        public List<Cart> GetCartItems()
        {
            return _dbConnection.Table<Cart>().ToList();
        }

        public void RemoveFromCart(int itemId)
        {
            var item = _cartItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(i => decimal.TryParse(i.price, out var price) ? price : 0);
        }
    }
}
