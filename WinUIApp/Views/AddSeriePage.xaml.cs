using Microsoft.UI.Xaml.Controls;
using WinUIApp.ViewModels;

namespace WinUIApp.Views;

public sealed partial class AddSeriePage : Page
{
    public AddSerieViewModel ViewModel { get; }

    public AddSeriePage()
    {
        this.InitializeComponent();
        ViewModel = new AddSerieViewModel();
    }
}