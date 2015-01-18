using System;
using System.Collections.Generic;

namespace Achievments.AchievmentProperties
{
    /// <summary>
    /// Тип свойства достижения
    /// </summary>
    [Serializable]
    public class AchievmentPropertyType
    {
        public int AchievmentPropertyTypeId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип, для восстановления значения из строки
        /// </summary>
        public string Type { get; set; }

        public virtual ICollection<AchievmentProperty> Properties { get; set; } 

        /// <summary>
        /// Для каких достижений может применяться
        /// </summary>
        public AchievmentType ApplicableToTypes { get; set; }

        public static bool operator == (AchievmentPropertyType a, AchievmentPropertyType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (b != null && (a != null && a.AchievmentPropertyTypeId == b.AchievmentPropertyTypeId))
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(AchievmentPropertyType a, AchievmentPropertyType b)
        {
            return !(a == b);
        }

    }
}
