using System.Collections.Generic;
using System.Linq;
using Models.Achievments;
using Models.Achievments.AchievmentProperties;

namespace Models.Commands.Filters
{
    /// <summary>
    /// фильтр по точному совпадению значения enum- свойства
    /// </summary>
    public class EnumExactFilter : BaseFilter
    {
        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            return achievments.Where(achievment => achievment.EnumProperties.Any(
                            property => property.Type == Type
                            && property.SelectedValue == ExactValue))
                            .ToList();
        }
        public virtual EnumPropertyType Type { get; set; }

        public virtual EnumPropertyTypeValue ExactValue { get; set; }
    }
}