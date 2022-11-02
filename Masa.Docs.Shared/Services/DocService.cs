using System.Globalization;

namespace Masa.Docs.Shared.Services;

public class DocService
{
    private static readonly ConcurrentCache<string, ValueTask<string>> ComponentCache = new();

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

    public async Task<string> ReadAsync(string group, string title)
    {
        var key = $"{group}/{title}:{_currentCulture}";
        return await ComponentCache.GetOrAdd(key, async _ =>
        {
            var md = await _httpClient.GetStringAsync($"_content/Masa.Docs.Shared/docs/pages/{group}/{title}/{_currentCulture}.md");

            // todo: if md is null, throw a exception?

            return md;
        });
    }
}
