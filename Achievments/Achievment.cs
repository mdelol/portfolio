using System;
using System.Collections.Generic;
using Achievments.AchievmentProperties;

namespace Achievments
{
    /// <summary>
    /// Достижение
    /// </summary>
    public class Achievment
    {
        /// <summary>
        /// Свойства достижения
        /// </summary>
        public virtual List<AchievmentProperty> Properties { get; set; }

        public virtual List<EnumProperty> EnumProperties { get; set; } 

        /// <summary>
        /// Тип достижения
        /// </summary>
        public AchievmentType Type { get; set; }

        public int AchievmentId { get; set; }
    }
}