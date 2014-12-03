using System.Collections.Generic;
using Achievments;

namespace Command.Filters
{
    public abstract class BaseFilter
    {
        public int BaseFilterId { get; set; }
        public abstract List<Achievment> Filter(IEnumerable<Achievment> achievments);
    }
}
