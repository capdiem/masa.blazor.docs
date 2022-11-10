using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.Steppers
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MStepper)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Index>(0);
            builder.CloseComponent();
        };
    }
}
