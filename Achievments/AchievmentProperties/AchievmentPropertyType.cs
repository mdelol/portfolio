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
    }
}
