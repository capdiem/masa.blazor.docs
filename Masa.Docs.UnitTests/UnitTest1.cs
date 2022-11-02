using System.Buffers;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.Json;
using BlazorComponent;
using Masa.Docs.Shared.Services;
using Xunit.Sdk;

namespace Masa.Docs.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var jsonString = @"
[
  {
    ""title"": ""introduction"",
    ""icon"": ""mdi-heart"",
    ""items"": [
        ""why-masa-blazor"",
        ""roadmap""
    ]
  },
  {
    ""title"": ""ui-components"",
    ""icon"": ""mdi-heart"",
    ""group"": ""components"",
    ""items"": [
        ""alerts"",
        {
            ""title"": ""bars"",
            ""group"": ""components"",
            ""items"": [
                ""app-bars"",
                ""toolbars"",
                ""system-bars""
            ]
        }
    ]
  }
]";

        // var result = JsonSerializer.Deserialize<List<NavItem>>(jsonString, new JsonSerializerOptions()
        // {
        //     Converters = { new NavItemsJsonConverter() }
        // });

        var options = new JsonReaderOptions
        {
        };

        var bytes = Encoding.UTF8.GetBytes(jsonString);
        var stream = new MemoryStream(bytes);
        var buffer = new byte[4096];
        stream.Read(buffer);
        var reader = new Utf8JsonReader(buffer);

        reader.Read();

        var list = ReadSubItems(ref reader);
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
