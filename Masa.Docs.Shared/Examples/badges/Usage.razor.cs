using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.badges
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        private static readonly ParameterList<bool> ToggleParameters = new()
        {
            { nameof(MBadge.Bordered), false },
            { nameof(MBadge.Inline), false },
            { nameof(MBadge.Tile), false },
        };

        private static readonly ParameterList<CheckboxParameter> CheckboxParameters = new()
        {
            { nameof(MBadge.Bottom), new CheckboxParameter("false", true) },
            { nameof(MBadge.Dot), new CheckboxParameter("false", true) },
            { nameof(MBadge.Left), new CheckboxParameter("false", true) },
            { nameof(MBadge.OverLap), new CheckboxParameter("false", true) },
        };

        public Usage() : base(typeof(MBadge), ToggleParameters, CheckboxParameters) { }
    }
}
