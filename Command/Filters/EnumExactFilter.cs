using System.Collections.Generic;
using System.Linq;
using Achievments;
using Achievments.AchievmentProperties;

namespace Command.Filters
{
    public class EnumExactFilter : BaseFilter
    {
        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment => achievment.EnumProperties.Any(
                            property => property.Type == Type
                            && property.SelectedValue == ExactValue))
                            .ToList();
        }
        public EnumPropertyType Type { get; set; }

        public EnumPropertyTypeValue ExactValue { get; set; }
    }
}