using System;
using System.Collections.Generic;

namespace Achievments
{
    /// <summary>
    /// Достижение
    /// </summary>
    [Serializable]
    public class Achievment
    {
        /// <summary>
        /// Свойства достижения
        /// </summary>
        public virtual List<AchievmentProperty> Properties { get; set; }

        /// <summary>
        /// Тип достижения
        /// </summary>
        public AchievmentType Type { get; set; }

        public int AchievmentId { get; set; }
    }
}