namespace Masa.Docs.Shared.Examples.avatars
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        private static readonly ParameterList<bool> ToggleParameters = new()
        {
            { nameof(MAvatar.Rounded), false },
            { nameof(MAvatar.Tile), false },
        };

        private static readonly ParameterList<SliderParameter> SliderParameters = new()
        {
            { nameof(MAvatar.Size), new SliderParameter(56, 25, 128) }
        };

        private static readonly ParameterList<SelectParameter>? SelectParameters = new()
        {
            { nameof(MAvatar.Color), new SelectParameter(new List<string>() { "primary", "accent", "warning lighten-2", "teal", "grey lighten-2" }) },
        };

        public Usage() : base(typeof(MAvatar), ToggleParameters, null, SliderParameters, SelectParameters)
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
                nameof(MAvatar.Size) => (StringNumber)(double)parameter.Value,
                _ => parameter.Value
            };
        }
    }
}
