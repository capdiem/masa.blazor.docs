
namespace Masa.Docs.Shared.Examples.overlays.usages;

public class Usage : Components.Usage
{
    protected override Type UsageWrapperType => typeof(UsageWrapper);

    public Usage() : base(typeof(MOverlay))
    {
    }
}