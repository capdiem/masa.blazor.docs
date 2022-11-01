using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Masa.Docs.Shared.Services;

public class AppService
{
    private readonly HttpClient _httpClient;

    private readonly Lazy<Task<List<NavItem>>> _navs;

    public AppService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _navs = new Lazy<Task<List<NavItem>>>(() =>
        {
            var navs = httpClient.GetFromJsonAsync<List<NavItem>>("_content/Masa.Docs.Shared/data/nav.json", new JsonSerializerOptions()
            {
            });

            return navs;
        });
    }

    public async Task<List<NavItem>> GetNavs()
    {
        return await _navs.Value;
    }
}

public class NavItemJsonConverter : JsonConverter<NavItem>
{
    public override NavItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        reader.Read();
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException();
        }

        var navItem = new NavItem();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return navItem;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case "title":
                        navItem.Title = reader.GetString();
                        break;
                    case "icon":
                        navItem.Icon = reader.GetString();
                        break;
                    case "group":
                        navItem.Group = reader.GetString();
                        break;
                    case "items":
                        navItem.Items = ReadSubItems(ref reader);
                        break;
                }
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, NavItem value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private List<NavItem> ReadSubItems(ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        var navItems = new List<NavItem>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var title = reader.GetString();
                navItems.Add(new NavItem(title));
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                
            }
        }

        return navItems;
    }
}

public class NavItem
{
    public string Title { get; set; }

    public string Group { get; set; }

    public string Icon { get; set; }

    public List<NavItem> Items { get; set; }

    public NavItem()
    {
    }

    public NavItem(string title)
    {
        Title = title;
    }
}
