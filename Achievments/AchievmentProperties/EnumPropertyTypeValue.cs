namespace Achievments.AchievmentProperties
{
    public class EnumPropertyTypeValue
    {
        public int EnumPropertyTypeValueId { get; set; }

        public EnumPropertyType EnumPropertyType { get; set; }

        public string Value { get; set; }

        public static bool operator ==(EnumPropertyTypeValue a, EnumPropertyTypeValue b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (b != null && (a != null && a.EnumPropertyTypeValueId == b.EnumPropertyTypeValueId))
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EnumPropertyTypeValue a, EnumPropertyTypeValue b)
        {
            return !(a == b);
        }
    }
}