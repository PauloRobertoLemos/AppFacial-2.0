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
            await DisplayAlert("Erro", "O endereço de email e senha são obrigatórios.", "OK");
            return;
        }

        // implementar a conexao com o banco de dados aqui
        if (email == "email" && password == "password")
        {
            // Credenciais corretas, redirecione para o painel do usuário
            await Navigation.PushAsync(new PanelUserPage());
        }
        else
        {
            // Credenciais inválidas, exiba uma mensagem de erro
            await DisplayAlert("Erro", "Credenciais inválidas. Tente novamente.", "OK");
        }
    }

    private void RecuperarSenhaClicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RecoverPass());
    }

    private void BtnUserRegister_Clicked(object sender, EventArgs e)
    {
        // original ---> Navigation.PushAsync(new RegisterUserPage());
        // Após manter Navigation ORIGINAL, apagar a linha abaixo
        Navigation.PushAsync(new PanelUserPage());
    }
}