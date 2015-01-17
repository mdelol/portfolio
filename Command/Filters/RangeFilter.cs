using System;
using System.Collections.Generic;
using System.Linq;
using Achievments;
using Achievments.AchievmentProperties;

namespace Commands.Filters
{
    /// <summary>
    /// фильтр по диапазону
    /// </summary>
    public class RangeFilter : BaseFilter
    {
        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment =>achievment.Properties.Any
                (property =>property.Type == Type 
                && Convert.ToDouble(property.Value) > LowerValue 
                && Convert.ToDouble(property.Value) < UpperValue))
                .ToList();
        }

        public double LowerValue { get; set; }

        public double UpperValue { get; set; }

        public virtual AchievmentPropertyType Type { get; set; }
    }
}
