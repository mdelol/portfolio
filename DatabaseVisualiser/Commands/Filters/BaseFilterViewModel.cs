using Models.Commands.Filters;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Commands.Filters
{
    public class BaseFilterViewModel<T> : BaseViewModel where T: BaseFilter
    {
        protected T Model;

        public BaseFilterViewModel(T model)
        {
            Model = model;
        }
    }
}