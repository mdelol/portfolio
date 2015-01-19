using System.Collections.ObjectModel;
using System.Linq;
using Commands.Filters;
using Models.Commands.Filters;

namespace DatabaseVisualiser.Commands.Filters
{
    public class ComplexFilterViewModel : BaseFilterViewModel<ComplexFilter>
    {
        public ComplexFilterViewModel(ComplexFilter model) : base(model)
        {
            //Filters=new ObservableCollection<BaseFilterViewModel<BaseFilter>>();
            //foreach (var baseFilter in model.Filters)
            //{
            //    var ef = baseFilter as ExactFilter;
            //    if(ef!=null)
            //    Filters.Add(new ExactFilterViewModel(ef));
            //}
        }

        public ObservableCollection<BaseFilterViewModel<BaseFilter>> Filters { get; set; }
    }
} 