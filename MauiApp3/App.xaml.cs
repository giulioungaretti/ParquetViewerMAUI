namespace MauiApp3;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();

		MainPage = new NavigationPage(mainPage);
	}
}
