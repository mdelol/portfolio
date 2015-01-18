using System.Collections.Generic;
using System.Linq;
using Models.Achievments;
using Models.Commands.Filters;

namespace Commands.Filters
{
    /// <summary>
    /// Фильтр, состоящий из нескольких однотипных фильтров, 
    /// TODO возможно, следует сделать дженериком
    /// </summary>
    public class ComplexFilter : BaseFilter 
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