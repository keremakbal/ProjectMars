using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public static class EnumExtension
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum @enum)
            where TAttribute : Attribute
        {
            var type = @enum.GetType();
            var name = Enum.GetName(type, @enum);
            return type.GetField(name)
                .GetCustomAttributes(true)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
        public static string GetValue(this Enum @enum)
        {
            var attribute = GetAttribute<InformationAttribute>(@enum);
            return attribute != null ? attribute.Value : null;
        }
        public static string GetDescription(this Enum @enum)
        {
            var attribute = GetAttribute<InformationAttribute>(@enum);
            return attribute != null ? attribute.Description : null;
        }
        public static string GetName(this Enum @enum)
        {
            return Enum.GetName(@enum.GetType(), @enum);
        }
        public static IDictionary<string, string> GetValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<object>().ToDictionary(k => ((Enum)k).GetValue(), r => ((Enum)r).GetName());
        }
        public static TEnum GetMemberByValue<TEnum>(string value) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), GetValues<TEnum>()[value]);
        }
    }
}
