using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WinUIApp.Models;

namespace WinUIApp.Services;
// ... (le reste du code est bon)

public class WsService
{
    private readonly HttpClient _httpClient;

    public WsService()
    {
        _httpClient = new HttpClient();
        // Vérifie que ce port est toujours le bon (celui de ton API lancée)
        _httpClient.BaseAddress = new Uri("https://localhost:7205/");
    }

    public async Task<Serie?> GetSerieAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Serie>($"api/Series/{id}");
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> PostSerieAsync(Serie serie)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/Series", serie);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> PutSerieAsync(int id, Serie serie)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Series/{id}", serie);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteSerieAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/Series/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}