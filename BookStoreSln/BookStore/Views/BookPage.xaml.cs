using BookStore.ViewModels;

namespace BookStore.Views;

public partial class BookPage : ContentPage
{
	public BookPage(BookPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}