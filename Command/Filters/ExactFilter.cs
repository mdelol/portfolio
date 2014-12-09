﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievments;

namespace Command.Filters
{
    public class ExactFilter : BaseFilter
    {

        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment => achievment.Properties.Any(
                property => property.Type == Type
                && property.Value == ExactValue))
                .ToList();
        }

        public virtual AchievmentPropertyType Type { get; set; }

        public string ExactValue { get; set; }

    }
}
