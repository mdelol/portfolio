using System.Collections.Generic;

namespace Models.Achievments.AchievmentProperties
{
    /// <summary>
    /// Тип enum - свойства
    /// </summary>
    public class EnumPropertyType
    {
        public int EnumPropertyTypeId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Допустимые значения
        /// </summary>
        public virtual List<EnumPropertyTypeValue> AvailibleValues { get; set; }

        /// <summary>
        /// Для каких достижений может применяться
        /// </summary>
        public AchievmentType ApplicableToTypes { get; set; }

        public static bool operator == (EnumPropertyType a, EnumPropertyType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (b != null && a != null && a.EnumPropertyTypeId==b.EnumPropertyTypeId)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(EnumPropertyType a, EnumPropertyType b)
        {
            return !(a == b);
        }
    }
}