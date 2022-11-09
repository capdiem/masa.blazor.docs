using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Components.Routing;

namespace Masa.Docs.Shared.Pages;

public partial class Document : IDisposable
{
    [Inject]
    private DocService DocService { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private AppService AppService { get; set; } = null!;

    [Parameter]
    public string Category { get; set; } = null!;

    [Parameter] public string Page { get; set; } = null!;

    private string? _md;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await ReadDocumentAsync();

            StateHasChanged();
        }
    }

    private async void NavigationManagerOnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        await ReadDocumentAsync();
        await InvokeAsync(StateHasChanged);
    }

    private void OnTocParsed(List<MarkdownItTocContent>? contents)
    {
        AppService.Toc = contents;
    }

    private async Task ReadDocumentAsync()
    {
        try
        {
            Debug.WriteLine("read document...");
            _md = await DocService.ReadDocumentAsync(Category, Page);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= NavigationManagerOnLocationChanged;
    }
}
