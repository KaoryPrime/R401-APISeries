using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using WinUIApp.Models;
using WinUIApp.Services;

namespace WinUIApp.ViewModels;

public partial class SearchSerieViewModel : ObservableObject
{
    private readonly WsService _wsService;

    [ObservableProperty]
    private int idSearch;

    [ObservableProperty]
    private Serie serieToDisplay;

    public SearchSerieViewModel()
    {
        _wsService = new WsService();
        SerieToDisplay = new Serie();
    }

    [RelayCommand]
    public async Task Search()
    {
        var result = await _wsService.GetSerieAsync(IdSearch);
        if (result != null)
        {
            SerieToDisplay = result;
        }
        else
        {
            await ShowDialog("Erreur", "Série introuvable.");
            SerieToDisplay = new Serie(); // Reset
        }
    }

    [RelayCommand]
    public async Task Modify()
    {
        if (SerieToDisplay.Serieid == 0) return;

        bool success = await _wsService.PutSerieAsync(SerieToDisplay.Serieid, SerieToDisplay);
        await ShowDialog(success ? "Succès" : "Erreur", success ? "Série modifiée !" : "Échec de la modification.");
    }

    [RelayCommand]
    public async Task Delete()
    {
        if (SerieToDisplay.Serieid == 0) return;

        bool success = await _wsService.DeleteSerieAsync(SerieToDisplay.Serieid);
        if (success)
        {
            await ShowDialog("Succès", "Série supprimée !");
            SerieToDisplay = new Serie(); // Reset
        }
        else
        {
            await ShowDialog("Erreur", "Échec de la suppression.");
        }
    }

    private async Task ShowDialog(string title, string content)
    {
        ContentDialog dialog = new ContentDialog
        {
            XamlRoot = App.MainWindow.Content.XamlRoot,
            Title = title,
            Content = content,
            CloseButtonText = "OK"
        };
        await dialog.ShowAsync();
    }
}