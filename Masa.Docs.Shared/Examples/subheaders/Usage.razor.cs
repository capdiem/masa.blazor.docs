﻿using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared.Examples.Subheaders;

public class Usage : Components.Usage
{
    public Usage() : base(typeof(MSubheader))
    {
    }

    protected override RenderFragment GenChildContent() => builder =>
    {
        builder.AddContent(0, "Subheader");
    };
}
