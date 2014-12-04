using System.Collections.Generic;

namespace Achievments.AchievmentProperties
{
    public class EnumPropertyType
    {
        public int EnumPropertyTypeId { get; set; }

        public string Name { get; set; }

        public virtual List<EnumPropertyTypeValue> AvailibleValues { get; set; }

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