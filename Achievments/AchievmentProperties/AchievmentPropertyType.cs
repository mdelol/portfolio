using System;

namespace Achievments
{
    /// <summary>
    /// Тип свойства достижения
    /// </summary>
    [Serializable]
    public class AchievmentPropertyType
    {
        public int AchievmentPropertyTypeId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

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
