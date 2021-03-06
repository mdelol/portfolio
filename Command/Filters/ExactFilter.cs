﻿using System.Collections.Generic;
using System.Linq;
using Achievments;
using Achievments.AchievmentProperties;

namespace Commands.Filters
{
    /// <summary>
    /// Фильтр по точному совпадению
    /// </summary>
    public class ExactFilter : TypeFilter
    {

        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment => achievment.Properties.Any(
                property => property.Type == Type
                && property.Value == ExactValue))
                .ToList();
        }

        public string ExactValue { get; set; }

    }
}
