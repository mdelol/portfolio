using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievments;

namespace Command.Filters
{
    class ExactFilter : BaseFilter
    {

        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment => achievment.Properties.Any(
                property => property.Type == ExactValue.Type
                && property.Value == ExactValue.Value))
                .ToList();
        }

        public AchievmentProperty ExactValue { get; set; }

    }
}
