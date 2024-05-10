using MauiAppXml.Entities;
using MauiAppXml.Repositories;
using MauiAppXml.Repositories.Interface;

namespace MauiAppXml;

public partial class LoginView : ContentPage
{
    private IRepository<int, User> _repository;

    public LoginView()
    {
        _repository = new UserRepository();
        InitializeComponent();
    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        var user= _repository.GetAll().Find(u => u.Email == email && u.Password == password);

        if (user is null) DisplayAlert("Aviso", "E-mail ou senha incorretos", "Ok");
        else MainPageNavigate();

    }

    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        User user = new User()
        {
            Email = email,
            Password = password
        };

        _repository.Add(user);
    }

    public async void MainPageNavigate()
    {
        await Navigation.PushAsync(new MainPage());
    }
}