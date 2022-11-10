﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.Images
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        protected override ParameterList<CheckboxParameter> GenCheckboxParameters() => new()
        {
           { nameof(MImage.Contain), new CheckboxParameter("false", true) },
        };

        protected override ParameterList<SliderParameter> GenSliderParameters() => new()
        {
           { nameof(MImage.MaxHeight), new SliderParameter(150, 0, 300) },
           { nameof(MImage.MaxWidth), new SliderParameter(250, 0, 500) },
        };

        public Usage() : base(typeof(MImage)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Index>(0);
            builder.CloseComponent();
        };

        protected override object? CastValue(ParameterItem<object?> parameter)
        {
            if (parameter.Value == null)
            {
                return parameter.Value;
            }

            return parameter.Key switch
            {
                nameof(MImage.MaxHeight) => (StringNumber)(double)parameter.Value,
                nameof(MImage.MaxWidth) => (StringNumber)(double)parameter.Value,
                _ => parameter.Value
            };
        }
    }
}
