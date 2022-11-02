﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.dividers
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MDivider)) { }

        protected override ParameterList<CheckboxParameter> GenCheckboxParameters() => new()
        {
            { nameof(MDivider.Inset), new CheckboxParameter("false", true) },
            { nameof(MDivider.Vertical), new CheckboxParameter("false", true) },
        };
    }
}
