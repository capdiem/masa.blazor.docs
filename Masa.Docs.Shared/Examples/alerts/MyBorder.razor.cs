using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Masa.Docs.Shared.Examples.alerts;

public partial class MyBorder : Border
{
    [CascadingParameter]
    public MMarkdownIt MarkdownIt { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
    }
}
