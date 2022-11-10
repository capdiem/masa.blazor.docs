using Masa.Blazor.Presets;

namespace Masa.Docs.Shared.Examples.Toast.Usages;

public class Usage : Components.Usage
{
    protected override Type UsageWrapperType => typeof(UsageWrapper);

    public Usage() : base(typeof(PToast))
    {
    }
  
}
