namespace Masa.Docs.Shared.Components;

public partial class Usage
{
    private readonly Type _type;

    private ParameterList<bool> _toggleParameters;
    private ParameterList<CheckboxParameter> _checkboxParameters;
    private ParameterList<SliderParameter> _sliderParameters;
    private ParameterList<SelectParameter> _selectParameters;
    private RenderFragment? _childContent;

    public Usage(Type type)
    {
        _type = type;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _toggleParameters = GenToggleParameters();
        _checkboxParameters = GenCheckboxParameters();
        _sliderParameters = GenSliderParameters();
        _selectParameters = GenSelectParameters();
        _childContent = GenChildContent();
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

            if (_childContent is not null)
            {
                dict.Add("ChildContent", _childContent);
            }

            return dict;
        }
    }

    protected virtual ParameterList<bool> GenToggleParameters() => new();
    protected virtual ParameterList<CheckboxParameter> GenCheckboxParameters() => new();
    protected virtual ParameterList<SliderParameter> GenSliderParameters() => new();
    protected virtual ParameterList<SelectParameter> GenSelectParameters() => new();
    protected virtual RenderFragment? GenChildContent() => default;

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

            var parameters = string.Join($"{Environment.NewLine}\t", parameterList);

            return parameterList.Count == 0
                ? $"<{componentName}></{componentName}>"
                : $"<{componentName}{Environment.NewLine}\t{parameters}>{Environment.NewLine}</{componentName}>";
        }
    }
}
