using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Mvvm.View;

public partial class LoginUserPage : ContentPage
{

    public LoginUserPage()
	{
        InitializeComponent();
        BindingContext = new LoginUserPageViewModel();
	}

   

    private void RecuperarSenhaClicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RecoverPass());
    }

    private void PainelTest_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PanelUserPage());
    }
}