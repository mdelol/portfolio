using System;

namespace Achievments.AchievmentProperties
{
    /// <summary>
    /// Свойство достижения
    /// </summary>
    [Serializable]
    public class AchievmentProperty
    {
        /// <summary>
        /// Значение свойства
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public virtual AchievmentPropertyType Type { get; set; }

        public int AchievmentPropertyId { get; set; }

        public virtual Achievment Achievment { get; set; }
    }
}