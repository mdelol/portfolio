using System.Collections.Generic;
using System.Linq;
using Achievments;

namespace Command.Filters
{
    public class ComplexFilter:BaseFilter 
    {
        public override List<Achievment> Filter(IEnumerable<Achievment> achievments)
        {
            var result = new List<Achievment>();
            foreach (var filter in Filters)
            {
                result.AddRange(filter.Filter(achievments).Where(x=>result.All(y => y.AchievmentId != x.AchievmentId)));
            }
            return result;
        }

        public virtual List<BaseFilter> Filters { get; set; }
    }
}