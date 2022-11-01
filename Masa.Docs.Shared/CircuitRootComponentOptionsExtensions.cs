using Masa.Docs.Shared.Examples.alerts;
using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared;

public static class CircuitRootComponentOptionsExtensions
{
    public static void RegisterCustomElementsOfMasaDocs(this IJSComponentConfiguration options)
    {
        options.RegisterCustomElement<Border>("alerts-prop-border");
        options.RegisterCustomElement<Usage>("alerts-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.avatars.Usage>("avatars-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.badges.Usage>("badges-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.banners.Usage>("banners-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.app_bars.Usage>("app-bars-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.toolbars.Usage>("toolbars-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.system_bars.Usage>("system-bars-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.bottom_navigation.Usage>("bottom-navigation-usage");
        options.RegisterCustomElement<Masa.Docs.Shared.Examples.breadcrumbs.Usage>("breadcrumbs-usage");
    }
}
