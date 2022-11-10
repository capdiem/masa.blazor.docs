using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared.Examples.Modals;

public class Usage : Masa.Docs.Shared.Components.Usage
{
    public Usage() : base(typeof(PModal))
    {
    }

    protected override RenderFragment GenChildContent() => builder =>
    {
        builder.AddContent(0, "Content");
    };

    protected override Dictionary<string, object>? GenAdditionalParameters()
    {
        return new Dictionary<string, object>()
        {
            { nameof(PModal.Title),"Title"},
            { nameof(PModal.Width),(StringNumber)"500"},
            {
                nameof(PModal.ActivatorContent), new RenderFragment<ActivatorProps>(context => builder =>
                {
                    builder.OpenComponent<MButton>(0);
                    builder.AddMultipleAttributes(1, context.Attrs);
                    builder.AddChildContent(2, "Activator");
                    builder.CloseComponent();
                })
            }
        };
    }
}
