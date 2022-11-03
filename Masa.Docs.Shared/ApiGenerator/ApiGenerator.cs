namespace Masa.Docs.Shared.ApiGenerator;

public static class ApiGenerator
{
    public static Dictionary<string, object> parametersCache = new();

    static ApiGenerator()
    {
        var assembly = typeof(MApp).Assembly;
        var componentBaseType = typeof(ComponentBase);
        var componentTypes = assembly.GetTypes().Where(type => componentBaseType.IsAssignableFrom(type));
        var mComponentTypes = componentTypes.Where(type => type.Name.StartsWith("M"));
        var pComponentTypes = componentTypes.Where(type => type.Name.StartsWith("P"));

        foreach (var type in mComponentTypes)
        {
            var parameterProps = type.GetProperties()
                                     .Where(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParameterAttribute)));
            var contentProps = parameterProps.Where(prop => prop.PropertyType == typeof(RenderFragment) || (prop.PropertyType.IsGenericType &&
                prop.PropertyType == typeof(RenderFragment<>).MakeGenericType(prop.PropertyType.GenericTypeArguments[0])));
            var eventProps = parameterProps.Where(prop => prop.PropertyType == typeof(EventCallback) || (prop.PropertyType.IsGenericType &&
                prop.PropertyType == typeof(EventCallback<>).MakeGenericType(prop.PropertyType.GenericTypeArguments[0])));
            var defaultProps = parameterProps.Where(prop =>
                contentProps.Any(renderFragmentProp => renderFragmentProp == prop) is false &&
                eventProps.Any(eventProps => eventProps == prop) is false);

            var name = GetTypeName(type);

            if (!parametersCache.ContainsKey(name))
            {
                continue;
            }

            var parameters = defaultProps.Where(prop => IgnoreProps(prop.Name))
                                         .Select(prop => new ParameterInfo()
                                         {
                                             Name = prop.Name,
                                             Type = "TODO",
                                         });
        }
    }

    static string GetTypeName(Type componentType)
    {
        return componentType.IsGenericType
            ? componentType.Name.Remove(componentType.Name.IndexOf('`'))
            : componentType.Name;
    }

    static bool IgnoreProps(string name)
    {
        return name is not "Attributes" and not "RefBack";
    }
}

public class ParameterInfo
{
    public string Name { get; set; }

    public string Type { get; set; }

    public string Default { get; set; }

    public string? Description { get; set; } // todo: description of api
}
