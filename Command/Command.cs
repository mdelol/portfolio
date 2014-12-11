using System.Collections.Generic;
using System.Linq;
using Achievments;
using Commands.Filters;

namespace Commands
{
    /// <summary>
    /// Команда
    /// </summary>
    public class Command
    {
        public int CommandId { get; set; }

        /// <summary>
        /// Название команды
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фильтры, формирующие результаты
        /// </summary>
        public virtual List<BaseFilter> Filters { get; set; }

        /// <summary>
        /// команда, результаты которой будут использоваться как начальные для фильтрования
        /// </summary>
        public Command ParentCommand { get; set; }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Achievment> Execute()
        {
            var baseList = new List<Achievment>();
            if (ParentCommand != null)
            {
                baseList.AddRange(ParentCommand.Execute());
            }
            else
            {
                //Тут должно быть получение достижений для человека, который вызывает эту команду
            }

            var filters = new List<BaseFilter>(Filters);
            return ApplyFilterOrGoDown(filters, baseList);
        }

        /// <summary>
        /// рекурсивный обход всех фильтров
        /// </summary>
        private IEnumerable<Achievment> ApplyFilterOrGoDown(List<BaseFilter> filters, IEnumerable<Achievment> achievments)
        {
            var filter = filters.First();
            filters.RemoveAt(0);
            if (filters.Count == 0)
            {
                return filter.Filter(achievments);
            }
            return filter.Filter(ApplyFilterOrGoDown(filters, achievments));
        }
    }
}