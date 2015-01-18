namespace Models.Achievments.AchievmentProperties
{
    /// <summary>
    /// Значение enum - свойства
    /// </summary>
    public class EnumPropertyTypeValue
    {
        public int EnumPropertyTypeValueId { get; set; }

        /// <summary>
        /// Для какого типа применяется
        /// </summary>
        public EnumPropertyType EnumPropertyType { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
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