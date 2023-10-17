using System.Reflection;

namespace Fpl.Portal.Common.Attributes;

public class FplSourceInfoAttribute : Attribute
{
    public string Name { get; }
    public bool DbNullable { get; }

    public FplSourceInfoAttribute(string name, bool dbNullable = false)
    {
        Name = name;
        DbNullable = dbNullable;
    }

    public static FplSourceInfoAttribute On<TModelType>(string propertyName)
    {
        return typeof(TModelType)
                   .GetProperty(propertyName)
                   ?.GetCustomAttribute<FplSourceInfoAttribute>()
               ?? throw new ArgumentException(
                   $"{typeof(TModelType).Name} has no SourceName attribute for {propertyName}");
    }
}