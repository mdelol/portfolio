using System.Runtime.InteropServices;
using Models.Commands.Filters;

namespace DatabaseVisualiser.Commands.Filters
{
    public class ExactFilterViewModel : TypeFilterViewModel<ExactFilter>
    {
        public ExactFilterViewModel(ExactFilter model) : base(model)
        {
        }

        public string ExactValue
        {
            get
            {
                return Model.ExactValue;
            }
            set
            {
                Model.ExactValue = value;
            }
        }

    }
}