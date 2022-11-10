﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.BottomNavigation
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<UsageTemplate>(0);
            builder.CloseComponent();
        };

        public Usage() : base(typeof(MBottomNavigation)) { }
    }
}