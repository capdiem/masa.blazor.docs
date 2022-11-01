using Microsoft.AspNetCore.Components.Rendering;

namespace Masa.Docs.Shared.Components;

public class AppHeading : ComponentBase
{
    [Parameter]
    public int Level { get; set; } = 1;

    [Parameter]
    public string? Href { get; set; }

    [Parameter, EditorRequired]
    public string Content { get; set; }

    private static Dictionary<int, string> _map = new()
    {
        { 1, "text-h3 text-sm-h3 mb-4" },
        { 2, "text-h4 text-sm-h4 mb-3" },
        { 3, "text-h5 mb-2" },
        { 4, "text-h6 mb-2" },
        { 5, "text-subtitle-1 font-weight-medium mb-2" },
    };

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, $"h{Level}");
        builder.AddAttribute(1, "class", $"m-heading {_map[Level]}");
        builder.AddContent(2, (builder) =>
        {
            builder.OpenElement(0, "a");
            builder.AddAttribute(1, "href", Href);
            builder.AddAttribute(2, "class", "text-decoration-none text-right text-md-left");
            // builder.AddAttribute(3, "click", );
            builder.AddContent(4, "#");
            builder.CloseElement();
        });
        builder.AddContent(3, Content);
        builder.CloseElement();
    }
}
