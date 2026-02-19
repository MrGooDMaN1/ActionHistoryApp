using System.Net.Http.Json;
using ActionHistoryApp.Shared;

namespace ActionHistoryApp.Client.Services;

public class ActionApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ActionApiService> _logger;

    public ActionApiService(HttpClient httpClient, ILogger<ActionApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<ActionItemDto>?> GetAllActionsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<ActionItemDto>>("api/actions");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении историй действий");
            throw;
        }
    }


    public async Task<ActionItemDto?> AddActionAsync(ActionItemDto action)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/actions", action);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ActionItemDto>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добовлении истории действий");
            throw;
        }
    }

    public async Task UpdateActionAsync(int id, ActionItemDto action)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/actions/{id}", action);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка обновления истории действия: {Id}", id);
            throw;
        }
    }

    public async Task DeleteActionAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/actions/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении истории действия: {id}", id);
            throw;
        }
    }
}
