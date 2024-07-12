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
        }

        // Methods
        public List<Book> GetComingSoonBooks()
        {
            return _dbConnection.Table<Book>().ToList();
        }
    }
}
