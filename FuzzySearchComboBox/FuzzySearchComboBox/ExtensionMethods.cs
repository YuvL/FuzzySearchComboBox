using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace WPFControls.FuzzySearchComboBox
{
    public static class ExtensionMethods
    {
        public static TCustomAttribute GetCustomAttribute<TEnum, TCustomAttribute>(this TEnum enumValue) where TEnum : struct
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (memberInfo == null)
                return default(TCustomAttribute);
            return (TCustomAttribute) memberInfo.GetCustomAttributes(typeof (TCustomAttribute), false).FirstOrDefault();
        }

        public static string GetName<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            var customAttribute = GetCustomAttribute<TEnum, DisplayAttribute>(enumValue);
            return customAttribute != null ? customAttribute.Name : default(string);
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> sourceFirst, IEnumerable<TSource> sourceSecond, Func<TSource, TKey> key)
        {
            var keys = new HashSet<TKey>(sourceSecond.Select(key));

            foreach (TSource item in sourceFirst)
            {
                TKey k = key(item);
                if (keys.Contains(k))
                    continue;
                yield return item;
                keys.Add(k);
            }
        }
    }
}