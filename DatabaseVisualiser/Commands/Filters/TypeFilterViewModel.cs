using DatabaseVisualiser.Achievments.Properties.PropertyType;
using Models.Commands.Filters;

namespace DatabaseVisualiser.Commands.Filters
{
    public class TypeFilterViewModel<T> : BaseFilterViewModel<T> where T:TypeFilter
    {
        public TypeFilterViewModel(T model) : base(model)
        {

        }

        public PropertyTypeViewModel PropertyType
        {
            get
            {
                return new PropertyTypeViewModel(Model.Type);
            }

            set
            {
                Model.Type = value.GetModel();
            }
        }
    }
}