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
            _logger.LogError(ex, "Ошибка при получении действий API");
            throw;
        }
    }
}
