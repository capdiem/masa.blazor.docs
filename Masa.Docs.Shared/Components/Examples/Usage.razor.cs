namespace Masa.Docs.Shared.Components;

public partial class Usage
{
    private readonly Type _type;
    private readonly ParameterList<bool> _toggleParameters;
    private readonly ParameterList<CheckboxParameter> _checkboxParameters;
    private readonly ParameterList<SliderParameter> _sliderParameters;
    private readonly ParameterList<SelectParameter> _selectParameters;

    public Usage(Type type,
        ParameterList<bool>? toggleParameters = null,
        ParameterList<CheckboxParameter>? checkboxParameters = null,
        ParameterList<SliderParameter>? sliderParameters = null,
        ParameterList<SelectParameter>? selectParameters = null)
    {
        _type = type;
        _toggleParameters = toggleParameters ?? new ParameterList<bool>();
        _checkboxParameters = checkboxParameters ?? new ParameterList<CheckboxParameter>();
        _sliderParameters = sliderParameters ?? new ParameterList<SliderParameter>();
        _selectParameters = selectParameters ?? new ParameterList<SelectParameter>();
    }

    private Dictionary<string, object?> Parameters
    {
        get
        {
            var parameters = new List<ParameterItem<object?>>();
            parameters.AddRange(_toggleParameters.Select(item => new ParameterItem<object?>(item.Key, item.Value)));
            parameters.AddRange(_checkboxParameters.Select(item => new ParameterItem<object?>(item.Key, item.Value.Value)));
            parameters.AddRange(_sliderParameters.Select(item => new ParameterItem<object?>(item.Key, item.Value.Value)));
            parameters.AddRange(_selectParameters.Select(item => new ParameterItem<object?>(item.Key, item.Value.Value)));
            var dict = parameters.ToDictionary(item => item.Key, CastValue);
            // dict.Add("ChildContent", (RenderFragment)(builder => builder.AddContent(0, "I'm an Alert Usage Example")));
            return dict;
        }
    }

    protected virtual object? CastValue(ParameterItem<object?> parameter)
    {
        return parameter.Value;
    }

    protected virtual string FormatValue(string key, object value)
    {
        return value.ToString() ?? string.Empty;
    }

    protected virtual IEnumerable<ParameterItem<bool>> ActiveToggleParameters => _toggleParameters.Where(item => item.Value);
    protected virtual IEnumerable<ParameterItem<CheckboxParameter>> ActiveCheckboxParameters => _checkboxParameters.Where(item => item.Value.Value);
    protected virtual IEnumerable<ParameterItem<SliderParameter>> ActiveSliderParameters => _sliderParameters.Where(item => item.Value.Value > 0);
    protected virtual IEnumerable<ParameterItem<SelectParameter>> ActiveSelectParameters => _selectParameters.Where(item => item.Value.Value != null);

    private string SourceCode
    {
        get
        {
            var componentName = nameof(MAlert);

            var parameterList = new List<string>();
            parameterList.AddRange(ActiveToggleParameters.Select(item => item.Key));
            parameterList.AddRange(ActiveCheckboxParameters.Select(item =>
                item.Value.IsBoolean ? item.Key : $"{item.Key}=\"{FormatValue(item.Key, item.Value)}\""));
            parameterList.AddRange(ActiveSliderParameters.Select(item => $"{item.Key}=\"{FormatValue(item.Key, item.Value.Value)}\""));
            parameterList.AddRange(ActiveSelectParameters.Select(item => $"{item.Key}=\"{FormatValue(item.Key, item.Value.Value!)}\""));

            var parameters = string.Join(" ", parameterList);

            return $"<{componentName} {parameters}></{componentName}>";
        }
    }
}
