﻿using System;
using System.ComponentModel;

namespace Models.Achievments
{
    /// <summary>
    /// Тип достижения
    /// </summary>
    [Flags]
    public enum AchievmentType
    {
        [Description("Публикация")]
        Publication = 1,

        [Description("Другое")]
        Other = 2
    }
}