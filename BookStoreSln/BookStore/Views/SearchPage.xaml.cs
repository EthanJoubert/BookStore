using BookStore.ViewModels;

namespace BookStore.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}