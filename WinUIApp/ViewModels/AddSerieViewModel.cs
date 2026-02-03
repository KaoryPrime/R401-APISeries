using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using WinUIApp.Models;
using WinUIApp.Services;

namespace WinUIApp.ViewModels;

public partial class AddSerieViewModel : ObservableObject
{
    private readonly WsService _wsService;

    [ObservableProperty]
    private Serie serieToAdd;

    public AddSerieViewModel()
    {
        _wsService = new WsService();
        SerieToAdd = new Serie();
    }

    [RelayCommand]
    public async Task Add()
    {
        bool result = await _wsService.PostSerieAsync(SerieToAdd);

        ContentDialog dialog = new ContentDialog
        {
            XamlRoot = App.MainWindow.Content.XamlRoot,
            Title = result ? "Succès" : "Erreur",
            Content = result ? "Série ajoutée avec succès !" : "Impossible d'ajouter la série.",
            CloseButtonText = "OK"
        };

        await dialog.ShowAsync();
    }
}