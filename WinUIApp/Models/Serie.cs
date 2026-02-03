namespace WinUIApp.Models;

public class Serie
{
    public int Serieid { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string? Resume { get; set; }
    public int Nbsaisons { get; set; }
    public int Nbepisodes { get; set; }
    public int Anneecreation { get; set; }
    public string? Network { get; set; }
}