namespace Masa.Docs.Shared.Examples.alerts;

public class Usage : Masa.Docs.Shared.Components.Usage
{
    private static readonly ParameterList<bool> ToggleParameters = new()
    {
        { nameof(MAlert.Dense), false },
        { nameof(MAlert.Prominent), false },
        { nameof(MAlert.Outlined), false },
        { nameof(MAlert.Text), false },
        { nameof(MAlert.Shaped), false },
    };

    private static readonly ParameterList<CheckboxParameter> CheckboxParameters = new()
    {
        { nameof(MAlert.Dismissible), new CheckboxParameter("false", true) }
    };

    private static readonly ParameterList<SliderParameter> SliderParameters = new()
    {
        { nameof(MAlert.Elevation), new SliderParameter(0, 0, 24) }
    };

    private static readonly ParameterList<SelectParameter>? SelectParameters = new()
    {
        { nameof(MAlert.Color), new SelectParameter(new List<string>() { "red", "orange", "yellow", "green", "blue", "purple" }) },
        { nameof(MAlert.Icon), new SelectParameter(new List<string>() { "mdi-account", "mdi-heart" }) },
        { nameof(MAlert.Border), new SelectParameter(GetNames(Borders.None)) },
        { nameof(MAlert.Type), new SelectParameter(GetNames(AlertTypes.None)) }
    };

    private static readonly RenderFragment ChildContent = builder => builder.AddContent(0, "I'm an Alert Usage Example");

    public Usage() : base(typeof(MAlert), ToggleParameters, CheckboxParameters, SliderParameters, SelectParameters, ChildContent)
    {
    }

    protected override object? CastValue(ParameterItem<object?> parameter)
    {
        if (parameter.Value == null)
        {
            return parameter.Value;
        }

        return parameter.Key switch
        {
            nameof(MAlert.Icon) => (StringBoolean)(string)parameter.Value,
            nameof(MAlert.Border) => Enum.Parse<Borders>((string)parameter.Value),
            nameof(MAlert.Type) => Enum.Parse<AlertTypes>((string)parameter.Value),
            nameof(MAlert.Elevation) => (StringNumber)(double)parameter.Value,
            _ => parameter.Value
        };
    }

    protected override string FormatValue(string key, object value)
    {
        return key switch
        {
            nameof(MAlert.Border) => $"{nameof(Borders)}.{value}",
            nameof(MAlert.Type) => $"{nameof(AlertTypes)}.{value}",
            _ => value.ToString() ?? string.Empty
        };
    }

    private static List<string> GetNames<TEnum>(params TEnum[] ignores) where TEnum : struct, Enum
    {
        var names = Enum.GetNames<TEnum>();
        var excludeNames = ignores.Select(e => e.ToString());
        return names.Where(name => !excludeNames.Contains(name)).ToList();
    }
}
