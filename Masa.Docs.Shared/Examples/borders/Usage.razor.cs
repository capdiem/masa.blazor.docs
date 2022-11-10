using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.Borders
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Border>(0);
            builder.CloseComponent();
        };

        public Usage() : base(typeof(MBorder)) { }
    }
}
