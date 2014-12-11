using System.Collections.Generic;
using Achievments;

namespace Commands.Filters
{
    /// <summary>
    /// Базовый класс для фильтров
    /// </summary>
    public abstract class BaseFilter
    {
        public int BaseFilterId { get; set; }
        public abstract List<Achievment> Filter(IEnumerable<Achievment> achievments);
    }
}
