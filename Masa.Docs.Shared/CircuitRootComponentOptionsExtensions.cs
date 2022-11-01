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
    }
}
