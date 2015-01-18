using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DataLayer.Repositories;
using Models.Achievments.AchievmentProperties;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments.Properties.PropertyType
{
    class PropertyTypesViewModel : BaseViewModel
    {
        private PropertyTypeViewModel _selectedViewModel;

        public PropertyTypesViewModel()
        {
            var achievmentPropertyTypes = PropertyTypesRepository.GetInstance().GetObjects();
            PropertyTypes = new ObservableCollection<PropertyTypeViewModel>(achievmentPropertyTypes.Select(x => new PropertyTypeViewModel(x)).ToList());
            SelectedViewModel = PropertyTypes.FirstOrDefault();
            DeletedViewModels = new List<PropertyTypeViewModel>();
        }

        public ObservableCollection<PropertyTypeViewModel> PropertyTypes { get; set; }

        public PropertyTypeViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public List<PropertyTypeViewModel> DeletedViewModels { get; set; }

        public List<AchievmentPropertyType> GetModels()
        {
            return PropertyTypes.Select(x => x.GetModel()).ToList();
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    PropertyTypes.Add(new PropertyTypeViewModel(new AchievmentPropertyType() { Name = "Тип достижения", Type = typeof(string).ToString() }));
                    OnPropertyChanged("PropertyTypes");
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    if (SelectedViewModel.GetModel().AchievmentPropertyTypeId != 0)
                    {
                        DeletedViewModels.Add(SelectedViewModel);
                        PropertyTypes.Remove(SelectedViewModel);
                        SelectedViewModel = PropertyTypes.FirstOrDefault();
                    }
                    OnPropertyChanged("PropertyTypes");
                });
            }
        }
    }
}
