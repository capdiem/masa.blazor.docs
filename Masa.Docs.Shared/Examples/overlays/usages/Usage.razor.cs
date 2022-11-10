
namespace Masa.Docs.Shared.Examples.Overlays.Usages;

public class Usage : Components.Usage
{
    protected override Type UsageWrapperType => typeof(UsageWrapper);

    public Usage() : base(typeof(MOverlay))
    {
    }
}