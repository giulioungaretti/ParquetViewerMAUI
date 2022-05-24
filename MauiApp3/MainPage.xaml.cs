namespace MauiApp3;

public partial class MainPage : ContentPage
{
    public MainPage(ViewModels.ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

