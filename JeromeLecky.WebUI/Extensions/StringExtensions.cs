using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace JeromeLecky.WebUI.Extensions {
    public static class StringExtensions {

        public static string ToDisplayString<TEnum>(this TEnum e) where TEnum : IConvertible {
            if (e is Enum) {
                Type eType = e.GetType();
                Array enumValues = System.Enum.GetValues(eType);

                foreach (int val in enumValues) {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture)) {
                        var memInfo = eType.GetMember(eType.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null) {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }
    }
}