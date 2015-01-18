using System.Collections.Generic;
using Models.Achievments.AchievmentProperties;

namespace Models.Achievments
{
    /// <summary>
    /// Достижение
    /// </summary>
    public class Achievment
    {
        /// <summary>
        /// Имя достижения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойства достижения
        /// </summary>
        public virtual List<AchievmentProperty> Properties { get; set; }

        /// <summary>
        /// Свойства только с возможностью выбора из фиксированных значений
        /// </summary>
        public virtual List<EnumProperty> EnumProperties { get; set; }

        /// <summary>
        /// Тип достижения
        /// </summary>
        public AchievmentType Type { get; set; }

        public int AchievmentId { get; set; }

    }
}