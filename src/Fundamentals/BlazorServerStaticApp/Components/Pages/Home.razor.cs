namespace BlazorServerStaticApp.Components.Pages;

public partial class Home
{
    private string message;

    private void OnButtonClick()
    {
        message = "Clicked!";
        Console.WriteLine(message);

        // StateHasChanged();
    }
}
