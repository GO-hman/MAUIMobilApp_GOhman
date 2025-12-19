using Uppgift2_MAUIMobilApp_GOhman.ViewModels;

namespace Uppgift2_MAUIMobilApp_GOhman;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailsViewModel detailsVM)
	{
		InitializeComponent();
		BindingContext = detailsVM;
	}
}