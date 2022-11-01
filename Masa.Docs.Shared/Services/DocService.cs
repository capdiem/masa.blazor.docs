using System.Globalization;

namespace Masa.Docs.Shared.Services;

public class DocService
{
    private static readonly ConcurrentCache<string, ValueTask<string>> ComponentCache = new();

    private readonly HttpClient _httpClient;

    private string _currentCulture = "en-us";

    public DocService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void ChangeLanguage(CultureInfo culture)
    {
        _currentCulture = culture.Name;
    }

    public async Task<string> GetComponentAsync(string id)
    {
        var key = $"{id}:{_currentCulture}";
        return await ComponentCache.GetOrAdd(key, async _ =>
        {
            var md = await _httpClient.GetStringAsync($"_content/Masa.Docs.Shared/docs/pages/components/{id}/{_currentCulture}.md");

            // todo: if md is null, throw a exception?

            return md;
        });
    }
}
