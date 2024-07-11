using BookStore.Views;

namespace BookStore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("book", typeof(BookPage));
        }
    }
}
