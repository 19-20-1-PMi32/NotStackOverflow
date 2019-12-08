using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.Extentions
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                var stringAttribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (stringAttribute != null)
                {
                    return stringAttribute.Description;
                }

                return field.Name;
            }

            return null;
        }
    }
}
