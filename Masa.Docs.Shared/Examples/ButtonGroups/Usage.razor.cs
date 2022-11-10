using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.ButtonGroups
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MButtonGroup)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Index>(0);
            builder.CloseComponent();
        };
    }
}
