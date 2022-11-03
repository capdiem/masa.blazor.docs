using System.Net.Http.Json;
using System.Text.Json;

namespace Masa.Docs.Shared.Services;

public class AppService
{
    private readonly Lazy<Task<List<NavItem>>> _navs;

    public AppService(IHttpClientFactory factory)
    {
        var httpClient = factory.CreateClient("masa-docs");

        _navs = new Lazy<Task<List<NavItem>>>(async () =>
        {
            var navs = await httpClient.GetFromJsonAsync<List<NavItem>>("_content/Masa.Docs.Shared/data/nav.json", new JsonSerializerOptions()
            {
                Converters = { new NavItemsJsonConverter() }
            });

            return navs ?? new List<NavItem>();
        });
    }

    public async Task<List<NavItem>> GetNavs()
    {
        return await _navs.Value;
    }
}
