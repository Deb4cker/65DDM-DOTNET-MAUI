namespace MauiAppXml;

public partial class MainPage : ContentPage
{

    int count = 0;
    int count2 = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnNavigatorButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AnotherView());
    }

    private async void OnRequesterClicked(object sender, EventArgs e)
    {
        count2++;
        var client = new HttpClient();
        var uri = new Uri("http://localhost:5291/ddm");

        try
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                LbTitle.Text = text;
            } 
            else
            {
                LbTitle.Text = "Não consegui fazer a request, foi mal! :(";
            }


        } catch (Exception ex)
        {
            LbTitle.Text = "Não consegui fazer a request. Deu esse problema aqui: " + ex.Message;
        }

        LbSubTitle.Text = $"Tentou fazer a requisição {count2} vezes";
    }
}
