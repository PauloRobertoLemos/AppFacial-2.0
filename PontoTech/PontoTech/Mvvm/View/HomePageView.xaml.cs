using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Pages;


public partial class HomePageView : ContentPage
{
    public HomePageView()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}

   
}