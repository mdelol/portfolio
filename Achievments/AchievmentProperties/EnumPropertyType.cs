using System.Collections.Generic;

namespace Achievments.AchievmentProperties
{
    public class EnumPropertyType
    {
        public int EnumPropertyTypeId { get; set; }

        public string Name { get; set; }

        public List<EnumPropertyTypeValue> AvailibleAValues { get; set; }

        public AchievmentType ApplicableToTypes { get; set; }

    }
}