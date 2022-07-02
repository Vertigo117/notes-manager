using System.ComponentModel;

namespace NotesManager.Domain.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Возвращает значение атрибута <see cref="DescriptionAttribute"/>
    /// </summary>
    public static string? GetDescription<TEnum>(this TEnum enumValue) where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum)
            return null;

        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString()!);

        return fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), true)
            .Select(attribute => (DescriptionAttribute) attribute)
            .FirstOrDefault()
            ?.Description;
    }
}