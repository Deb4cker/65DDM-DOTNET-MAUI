namespace MauiAppXml;

public partial class AnotherView : ContentPage
{

    private Label _contentLabel;
    private Image _cowboyDotnetImage;

    public AnotherView()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        _contentLabel = new Label()
        {
            Text = "IAHUU",
            Style = Application.Current!.Resources["ScreenHeadline"] as Style,
        };

        _cowboyDotnetImage = new Image()
        {
            Source = "cowboy_dotnet_bot.png",
            HeightRequest = 185,
            Aspect = Aspect.AspectFit
        };

        Content = new StackLayout()
        {
            Children = { _contentLabel, _cowboyDotnetImage }
        };
    }
}