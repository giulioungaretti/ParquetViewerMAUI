using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiApp3.Services;
using MauiApp3.Views;

namespace MauiApp3.ViewModels;

public partial class ViewModel : ObservableObject
{
    readonly FileService fileService;
    readonly DetailPage detailPage;

    public ViewModel(FileService fileService, DetailPage detailPage)
    {
        this.fileService = fileService;
        this.detailPage = detailPage;
    }

    [ObservableProperty]
    string title;

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    Models.Table table;

    [ICommand]
    async Task GetTableAsync()
    {
        if (IsBusy)
        {
            return;
        }
        try
        {
            IsBusy = true;
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                if (result.FileName.EndsWith("parquet", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    Table = new Models.Table
                    {
                        Data = FileService.LoadAsync(stream),
                        Name = result.FileName
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(detailPage);
                    return;
                }
                await Application.Current.MainPage.DisplayAlert("Failure", "Only .parquet files are supported", "OK");
            }
            await Application.Current.MainPage.DisplayAlert("Failure ", $"File is empty", "OK");

        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("fail", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

}
