namespace Masa.Docs.Shared.Shared;

public class DefaultItem
{
    public string? Heading { get; set; }

    public bool Divider { get; set; }

    public string? Href { get; set; }

    public string? Icon { get; set; }

    public string? Title { get; set; }
    
    public StringNumber Value { get; set; }

    public List<DefaultItem> Children { get; set; } = new();

    public bool HasChildren => Children is not null && Children.Any();
}
