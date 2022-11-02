using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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

public class NavItemsJsonConverter : JsonConverter<List<NavItem>>
{
    public override List<NavItem>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return ReadSubItems(ref reader);
    }

    public override void Write(Utf8JsonWriter writer, List<NavItem> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private List<NavItem> ReadSubItems(ref Utf8JsonReader reader)
    {
        var list = new List<NavItem>();

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return list;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var title = reader.GetString();
                list.Add(new NavItem(title));
            }

            var navItem = new NavItem();
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                list.Add(navItem);
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read())
                {
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
                    else if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        list.Add(navItem);
                        break;
                    }
                }
            }
        }

        return list;
    }
}

public class NavItem
{
    public string Title { get; set; }

    public string? Group { get; set; }

    public string? Icon { get; set; }

    public List<NavItem>? Items { get; set; }

    public NavItem()
    {
    }

    public NavItem(string title)
    {
        Title = title;
    }

    public bool HasChildren => Items is not null && Items.Any();

    public string Segment => (Group ?? Title);
}
