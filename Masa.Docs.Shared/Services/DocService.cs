using System.Globalization;
using System.Net.Http.Json;

namespace Masa.Docs.Shared.Services;

public class DocService
{
    private readonly ConcurrentCache<string, ValueTask<string>> _documentCache = new();
    private readonly ConcurrentCache<string, ValueTask<string>> _exampleCache = new();
    private readonly ConcurrentCache<string, ValueTask<Dictionary<string, Dictionary<string, string>>?>> _apiCache = new();

    private readonly HttpClient _httpClient;

    private string _currentCulture = "en-us";

    public DocService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("masa-docs");
    }

    public void ChangeLanguage(CultureInfo culture)
    {
        _currentCulture = culture.Name;
    }

    public async Task<string> ReadDocumentAsync(string category, string title)
    {
        var key = $"{category}/{title}:{_currentCulture}";
        return await _documentCache.GetOrAdd(key,
            async _ => await _httpClient.GetStringAsync($"_content/Masa.Docs.Shared/docs/pages/{category}/{title}/{_currentCulture}.md"));
    }

    public async Task<string> ReadExampleAsync(string category, string title, string example)
    {
        var key = $"{category}/{title}/{example}";
        return await _exampleCache.GetOrAdd(key,
            async _ => await _httpClient.GetStringAsync($"_content/Masa.Docs.Shared/docs/pages/{category}/{title}/examples/{example}.txt"));
    }

    public async Task<Dictionary<string, Dictionary<string, string>>?> ReadApisAsync(string kebabCaseComponent)
    {
        var key = $"{kebabCaseComponent}:{_currentCulture}";

        try
        {
            return await _apiCache.GetOrAdd(key, async _ => await _httpClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, string>>>(
                $"_content/Masa.Docs.Shared/docs/pages/apis/{kebabCaseComponent}/{_currentCulture}.json"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}
