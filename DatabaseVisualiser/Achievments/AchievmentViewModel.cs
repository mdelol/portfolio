using System.Collections.ObjectModel;
using System.Linq;
using Achievments;
using Achievments.AchievmentProperties;
using DatabaseVisualiser.Achievments.Properties;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments
{
    public class AchievmentViewModel : BaseViewModel
    {
        private Achievment _model;

        public AchievmentViewModel(Achievment model)
        {
            _model = model;
            Properties = new ObservableCollection<PropertyViewModel>(_model.Properties.Select(x => new PropertyViewModel(x)));
        }

        public ObservableCollection<PropertyViewModel> Properties { get; set; }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Type
        {
            get
            {
                return _model.Type.GetDescription();
            }
        }
    }
}