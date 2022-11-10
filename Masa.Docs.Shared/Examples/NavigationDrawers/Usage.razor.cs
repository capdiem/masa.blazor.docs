namespace Masa.Docs.Shared.Examples.NavigationDrawers;

public class Usage : Masa.Docs.Shared.Components.Usage
{
    protected override RenderFragment GenChildContent() => builder =>
    {
        builder.OpenComponent<Index>(0);
        builder.CloseComponent();
    };

    public Usage() : base(typeof(MNavigationDrawer))
    {
    }
}