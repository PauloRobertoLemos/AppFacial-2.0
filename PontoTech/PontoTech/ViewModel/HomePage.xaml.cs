namespace PontoTech.Pages;


public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
	}

    private void BtnEntrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync (new LoginUserPage());

    }

    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new RegisterUserPage());

    }
}