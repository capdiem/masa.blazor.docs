using System.Globalization;
using System.Net;

namespace Masa.Docs.Shared.Pages;

public partial class Document
{
    [Inject]
    private DocService DocService { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public string Page { get; set; } = null!;

    [Parameter]
    public string Category { get; set; } = null!;

    [Parameter]
    [SupplyParameterFromQuery]
    public string? Tab { get; set; }

    private string? _md;

    private string? _prevCategory;
    private string? _prevPage;

    private string? _frontMatter;

    private bool IsApiTab => Tab is not null && Tab.Equals("api", StringComparison.OrdinalIgnoreCase);

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (Page != _prevPage || Category != _prevCategory)
        {
            _prevCategory = Category;
            _prevPage = Page;
            await ReadMarkdownAsync();
        }
    }

    private string _prevCulture = "en-US";

    private async Task ChangeCulture()
    {
        var culture = _prevCulture == "en-US" ? "zh-CN" : "en-US";
        _prevCulture = culture;
        DocService.ChangeLanguage(new CultureInfo(culture));
        await ReadMarkdownAsync();
    }

    private async Task ReadMarkdownAsync()
    {
        try
        {
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
}
