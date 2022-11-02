using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared;

public static class CircuitRootComponentOptionsExtensions
{
    public static void RegisterCustomElementsOfMasaDocs(this IJSComponentConfiguration options)
    {
        options.RegisterCustomElement<Examples.alerts.Border>("alerts-prop-border");
        options.RegisterCustomElement<Examples.alerts.Usage>("alerts-usage");
        options.RegisterCustomElement<Examples.avatars.Usage>("avatars-usage");
        options.RegisterCustomElement<Examples.badges.Usage>("badges-usage");
        options.RegisterCustomElement<Examples.banners.Usage>("banners-usage");
        options.RegisterCustomElement<Examples.app_bars.Usage>("app-bars-usage");
        options.RegisterCustomElement<Examples.toolbars.Usage>("toolbars-usage");
        options.RegisterCustomElement<Examples.system_bars.Usage>("system-bars-usage");
        options.RegisterCustomElement<Examples.bottom_navigation.Usage>("bottom-navigation-usage");
        options.RegisterCustomElement<Examples.bottom_sheets.Usage>("bottom-sheets-usage");
        options.RegisterCustomElement<Examples.breadcrumbs.Usage>("breadcrumbs-usage");
        options.RegisterCustomElement<Examples.buttons.Usage>("buttons-usage");
        options.RegisterCustomElement<Examples.cards.Usage>("cards-usage");
        options.RegisterCustomElement<Examples.chips.Usage>("chips-usage");
    }
}
