using System.ComponentModel;
using System.Reflection;

namespace Fpl.Portal.Common.Extensions;

public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum value)
    {
        var description = value.GetAttributeFieldValue<DescriptionAttribute>(d => d.Description);
        return description ?? value.ToString();
    }
    
    public static TEnum GetEnumValueFromDescription<TEnum>(this string description)
        where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum)
        {
            throw new ArgumentException($"{typeof(TEnum).FullName} is not an enum type.");
        }

        foreach (var field in typeof(TEnum).GetFields())
        {
            if (field.GetCustomAttribute(typeof(DescriptionAttribute)) is not DescriptionAttribute attribute) 
                continue;
            if (attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new ArgumentException($"Invalid description for {typeof(TEnum).FullName}.");
    }
    
    private static string? GetAttributeFieldValue<TAttribute>(
        this Enum value,
        Func<TAttribute, string> fieldSelector)
        where TAttribute : Attribute
    {
        var enumType = value.GetType();
        var enumValueName = value.ToString();
        var fieldInfo = enumType.GetField(enumValueName);

        if (fieldInfo == null) return null;

        var attribute = fieldInfo.GetCustomAttribute(typeof(TAttribute), false);

        return attribute == null ? null : fieldSelector((TAttribute)attribute);
    }
}