using System.Collections.Generic;
using Models.Achievments;

namespace Models.Commands.Filters
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
