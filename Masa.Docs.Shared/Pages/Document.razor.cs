using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using Masa.Docs.Shared.ApiGenerator;
using Microsoft.AspNetCore.Components.Routing;

namespace Masa.Docs.Shared.Pages;

public partial class Document : IDisposable
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

    private static readonly Dictionary<string, string> TagClassMap = new()
    {
        { "h2", "m-heading text-h4 text-sm-h4 mb-3" },
        { "h3", "m-heading text-h5 mb-2" },
        { "h4", "m-heading text-h6 mb-2" },
    };

    private string? _md;
    private string? _frontMatter;
    private Dictionary<string, List<ParameterInfo>> _parametersGroup = new();

    private bool IsApiTab => Tab is not null && Tab.Equals("api", StringComparison.OrdinalIgnoreCase);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;
    }

    private async void NavigationManagerOnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        await ReadAsync();
        await InvokeAsync(StateHasChanged);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await ReadAsync();
            StateHasChanged();
        }
    }

    private async Task ReadAsync()
    {
        if (IsApiTab)
        {
            await ReadApisAsync();
        }

        await ReadDocumentAsync();
    }

    private void NavigateToTab(string tab)
    {
        NavigationManager.NavigateTo(NavigationManager.GetUriWithQueryParameter("tab", tab));
    }

    private string _prevCulture = "en-US";

    private async Task ChangeCulture()
    {
        var culture = _prevCulture == "en-US" ? "zh-CN" : "en-US";
        _prevCulture = culture;
        DocService.ChangeLanguage(new CultureInfo(culture));
        await ReadDocumentAsync();
    }

    private async Task ReadDocumentAsync()
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

    private async Task ReadApisAsync()
    {
        var name = Page;
        
        var apiInPage = await DocService.ReadApiInPageAsync();

        if (apiInPage.ContainsKey(Page))
        {
            name = apiInPage[Page].FirstOrDefault() ?? Page;
        }

        name = FormatName(name);
        var component = ApiGenerator.ApiGenerator.parametersCache.Keys.FirstOrDefault(key => Regex.IsMatch(key, $"[M|P]{{1}}{name}$"));
        if (component is not null)
        {
            _parametersGroup = ApiGenerator.ApiGenerator.parametersCache[component];

            var descriptionGroup = await DocService.ReadApisAsync(Page);

            if (descriptionGroup is null)
            {
                return;
            }

            foreach (var group in descriptionGroup)
            {
                if (!_parametersGroup.ContainsKey(group.Key))
                {
                    continue;
                }

                var parameters = _parametersGroup[group.Key];
                foreach (var (prop, desc) in group.Value)
                {
                    var parameter = parameters.FirstOrDefault(param => param.Name.Equals(prop, StringComparison.OrdinalIgnoreCase));
                    if (parameter is not null)
                    {
                        parameter.Description = desc;
                    }
                }
            }
        }
    }

    private static string KebabToPascal(string name)
    {
        name = name.Trim('-');
        return string.Join("", name.Split('-').Select(item => char.ToUpper(item[0]) + item.Substring(1)));
    }

    private static string FormatName(string name)
    {
        // TODO: remove the last 's' if <> list contains the kebab-case name 
        name = name.TrimEnd('s');
        return KebabToPascal(name);
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= NavigationManagerOnLocationChanged;
    }
}
