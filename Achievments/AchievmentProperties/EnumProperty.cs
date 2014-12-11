﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievments.AchievmentProperties
{
    /// <summary>
    /// Свойство, доступное только для выбора, без возможности прямого вввода
    /// </summary>
    public class EnumProperty
    {
        public int EnumPropertyId { get; set; }

        /// <summary>
        /// Выбранное значение
        /// </summary>
        public virtual EnumPropertyTypeValue SelectedValue { get; set; }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public virtual EnumPropertyType Type { get; set; }

        public Achievment Achievment { get; set; }
    }
}
