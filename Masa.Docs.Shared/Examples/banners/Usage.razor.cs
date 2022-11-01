using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.banners
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        private static readonly ParameterList<bool> ToggleParameters = new()
        {
            { nameof(MBanner.SingleLine), false },
            { nameof(MBanner.Sticky), false },
            { nameof(MBanner.Dark), false },
        };

        public Usage() : base(typeof(MBanner)) { }
    }
}
