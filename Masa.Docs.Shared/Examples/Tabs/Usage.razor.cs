using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared.Examples.Tabs;

public class Usage : Components.Usage
{
    public Usage() : base(typeof(MTabs))
    {
    }

    protected override RenderFragment GenChildContent() => builder =>
    {
        builder.OpenComponent<MTab>(0);
        builder.AddChildContent(1, "Item One");
        builder.CloseComponent();

        builder.OpenComponent<MTab>(2);
        builder.AddChildContent(3, "Item Two");
        builder.CloseComponent();

        builder.OpenComponent<MTab>(4);
        builder.AddChildContent(5, "Item Three");
        builder.CloseComponent();
    };

}
