﻿using System;
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

        private static readonly ParameterList<CheckboxParameter> CheckboxParameters = new()
        {
            { nameof(MBadge.Bottom), new CheckboxParameter("false", true) },
            { nameof(MBadge.Dot), new CheckboxParameter("false", true) },
            { nameof(MBadge.Left), new CheckboxParameter("false", true) },
            { nameof(MBadge.OverLap), new CheckboxParameter("false", true) },
        };

        private static readonly RenderFragment ChildContent = builder =>
        {
            builder.OpenComponent<MIcon>(0);
            builder.AddAttribute(1, nameof(MIcon.Size), (StringNumber)36);
            builder.AddAttribute(2, "ChildContent", (RenderFragment)(b => b.AddContent(0, "mdi-heart")));
            builder.CloseComponent();
        };

        public Usage() : base(typeof(MBadge), ToggleParameters, CheckboxParameters, null, null, ChildContent) { }
    }
}
