namespace Masa.Docs.Shared;

public class NavItem
{
    public string Title { get; set; } = null!;

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
