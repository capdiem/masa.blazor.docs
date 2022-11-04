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
    public string Title { get; set; } = null!;

    [Parameter]
    public string Group { get; set; } = null!;

    [Parameter]
    [SupplyParameterFromQuery]
    public string? Tab { get; set; }

    private string? _md;

    private string? _prevGroup;
    private string? _prevTitle;

    private string? _frontMatter;

    private bool IsApiTab => Tab is not null && Tab.Equals("api", StringComparison.OrdinalIgnoreCase);

    private string ComponentName => "MAlert";

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (Title != _prevTitle || Group != _prevGroup)
        {
            _prevGroup = Group;
            _prevTitle = Title;
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
            _md = await DocService.ReadAsync(Group, Title);
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
