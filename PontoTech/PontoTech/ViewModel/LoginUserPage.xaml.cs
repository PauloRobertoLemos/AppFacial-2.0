namespace PontoTech.Pages;

public partial class LoginUserPage : ContentPage
{

    public LoginUserPage()
	{
		InitializeComponent();
	}

    private async void BtnUserLogin_Clicked(object sender, EventArgs e)
    {
        await ValidateLogin();
    }

    private async Task ValidateLogin()
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erro", "O endere�o de email e senha s�o obrigat�rios.", "OK");
            return;
        }

        // implementar a conexao com o banco de dados aqui
        if (email == "email" && password == "password")
        {
            // Credenciais corretas, redirecione para o painel do usu�rio
            await Navigation.PushAsync(new PanelUserPage());
        }
        else
        {
            // Credenciais inv�lidas, exiba uma mensagem de erro
            await DisplayAlert("Erro", "Credenciais inv�lidas. Tente novamente.", "OK");
        }
    }

    private void RecuperarSenhaClicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RecoverPass());
    }

    private void BtnUserRegister_Clicked(object sender, EventArgs e)
    {
        // original ---> Navigation.PushAsync(new RegisterUserPage());
        // Ap�s manter Navigation ORIGINAL, apagar a linha abaixo
        Navigation.PushAsync(new PanelUserPage());
    }
}