using Microsoft.UI.Xaml.Controls;
using WinUIApp.ViewModels;

namespace WinUIApp.Views;

public sealed partial class SearchSeriePage : Page
{
    public SearchSerieViewModel ViewModel { get; }

    public SearchSeriePage()
    {
        this.InitializeComponent();
        ViewModel = new SearchSerieViewModel();
    }
}