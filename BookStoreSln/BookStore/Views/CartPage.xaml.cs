using BookStore.ViewModels;

namespace BookStore.Views;

public partial class CartPage : ContentPage
{
	public CartPage(CartPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}