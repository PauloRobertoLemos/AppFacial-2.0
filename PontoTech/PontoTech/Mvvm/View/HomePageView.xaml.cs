using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Mvvm.View;


public partial class HomePageView : ContentPage
{
    public HomePageView()
	{
		InitializeComponent();
	}

    private void BtnEntrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUserPage());

    }

    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new RegisterUserPage());

    }

}