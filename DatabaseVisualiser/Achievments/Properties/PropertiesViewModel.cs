using System.Collections.Generic;
using System.Linq;
using DataLayer.Repositories;
using Models.Achievments;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments.Properties
{
    public class PropertiesViewModel : BaseViewModel
    {
        private PropertyViewModel _selectedProperty;

        public PropertiesViewModel()
        {
            List<Achievment> achievments = AchievmentsRepository.GetInstance().GetObjects();
            Properties = achievments.Select(x => x.Properties).First().Select(x=>new PropertyViewModel(x)).ToList();
        }

        public List<PropertyViewModel> Properties { get; set; }

        public PropertyViewModel SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value; 
                OnPropertyChanged("SelectedProperty");
            }
        }
    }
}