﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.Editor
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MEditor)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Basic>(0);
            builder.CloseComponent();
        };
    }
}
