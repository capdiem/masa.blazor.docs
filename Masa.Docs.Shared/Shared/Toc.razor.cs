using System.Text;
using BlazorComponent.JSInterop;
using BlazorComponent.Web;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Primitives;
using Microsoft.JSInterop;

namespace Masa.Docs.Shared.Shared;

public partial class Toc
{
    [Inject] private AppService AppService { get; set; } = null!;
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private string? _activeHash;
    private List<MarkdownItTocContent> _toc = new();
    private DotNetObjectReference<Toc>? objRef;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        AppService.TocChanged += AppServiceOnTocChanged;
        NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            objRef = DotNetObjectReference.Create(this);

            await JsRuntime.InvokeVoidAsync("registerWindowScrollEventForToc", objRef, "default-toc");
        }
    }

    private void NavigationManagerOnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
    }

    [JSInvokable("scrollToHashIfExists")]
    public void ScrollToHashIfExists()
    {
        Console.WriteLine("ScrollToHashIfExists");
    }

    private bool _scrolling;
    [JSInvokable("scrollToHash")]
    public async Task ScrollToHash(string hash)
    {
        _activeHash = hash;
        Console.WriteLine($"hash:{hash}");
        NavigationManager.ReplaceWithHash(hash);
        StateHasChanged();
    }

    private async Task ScrollIntoView(string elementId)
    {
        // TODO: remove the following lines when #40190 of aspnetcore resolved.
        // TODO: Blazor now does not support automatic scrolling of anchor points.
        // Check this when .NET 8 released.

        NavigationManager.ReplaceWithHash($"#{elementId}");
        await JsRuntime.ScrollToElement($"#{elementId}", AppService.AppBarHeight);
    }

    private void AppServiceOnTocChanged(object? sender, List<MarkdownItTocContent>? headings)
    {
        if (headings is null)
        {
            return;
        }

        _toc = headings;

        InvokeAsync(StateHasChanged);
    }

    private string GenClass(MarkdownItTocContent tocContent)
    {
        var builder = new StringBuilder();

        switch (tocContent.Level)
        {
            case 3:
                builder.Append("pl-6");
                break;
            case 4:
                builder.Append("pl-9");
                break;
            case 5:
                builder.Append("pl-12");
                break;
        }

        if (_activeHash is not null && _activeHash[1..].Equals(tocContent.Anchor, StringComparison.OrdinalIgnoreCase))
        {
            builder.Append(" primary--text");
        }
        else
        {
            builder.Append(" text--secondary");
        }

        return builder.ToString();
    }

    public void Dispose()
    {
        AppService.TocChanged -= AppServiceOnTocChanged;
        NavigationManager.LocationChanged -= NavigationManagerOnLocationChanged;
    }
}
