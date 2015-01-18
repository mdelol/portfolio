using System;
using System.ComponentModel;
using System.Linq;

namespace VisualTestApp.Common
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            var attribArray = fieldInfo.GetCustomAttributes(false);

            var descriptionAttribute = attribArray.FirstOrDefault(item => item is DescriptionAttribute) as DescriptionAttribute;

            return descriptionAttribute != null ? descriptionAttribute.Description : enumObj.ToString();
        } 
    }
}