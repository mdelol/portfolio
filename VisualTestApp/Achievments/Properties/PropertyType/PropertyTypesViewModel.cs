using System.Collections.Generic;
using System.Linq;
using Achievments.AchievmentProperties;
using DataLayer.Repositories;
using VisualTestApp.Common;

namespace VisualTestApp.Achievments.Properties.PropertyType
{
    class PropertyTypesViewModel : BaseViewModel
    {
        private PropertyTypeViewModel _selectedViewModel;

        public PropertyTypesViewModel()
        {
            var achievmentPropertyTypes = PropertyTypesRepository.GetInstance().GetObjects();
            PropertyTypes = achievmentPropertyTypes.Select(x => new PropertyTypeViewModel(x)).ToList();
            SelectedViewModel = PropertyTypes.FirstOrDefault();
        }

        public List<PropertyTypeViewModel> PropertyTypes { get; set; }

        public PropertyTypeViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public List<AchievmentPropertyType> GetModels()
        {
            return PropertyTypes.Select(x => x.GetModel()).ToList();
        }
    }
}
