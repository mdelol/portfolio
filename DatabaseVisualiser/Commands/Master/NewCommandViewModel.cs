using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xaml;
using Commands.Filters;
using DatabaseVisualiser.Achievments.Properties.PropertyType;
using DataLayer.Repositories;
using Models.Achievments.AchievmentProperties;
using Models.Commands.Filters;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Commands.Master
{
    public class NewCommandViewModel : BaseViewModel
    {
        public NewCommandViewModel()
        {
            CommandName = "Новая команда";
            UseAllAchievments = true;

            AvailableCommands = CommandsRepository.GetInstance().GetObjects().Select(x => new CommandViewModel(x)).ToList();
            SelectedCommand = AvailableCommands.FirstOrDefault();
            IsPublication = true;
            AvailableTypes = new ObservableCollection<PropertyTypeViewModel>(PropertyTypesRepository.GetInstance().GetNoTrackingObjects().Select(x => new PropertyTypeViewModel(x)));
            AvailableTypes.Add(ComplexStub);
            Filters=new ObservableCollection<BaseFilter>();
        }

        public string CommandName { get; set; }

        public bool UseAllAchievments { get; set; }

        public bool IsPublication { get; set; }

        public CommandViewModel SelectedCommand { get; set; }

        public List<CommandViewModel> AvailableCommands { get; set; }

        public PropertyTypeViewModel ComplexStub=new PropertyTypeViewModel(new AchievmentPropertyType(){Name = "Сложный фильтр"});
        public ObservableCollection<PropertyTypeViewModel> AvailableTypes { get; set; }

        public PropertyTypeViewModel SelectedType
        {
            get { return null; }
            set
            {
                if (!object.ReferenceEquals(value, ComplexStub))
                {
                    AvailableTypes.Remove(value);
                    Filters.Add(new ExactFilter()
                    {
                        Type = value.GetModel()
                    });
                }
                else
                {
                    AvailableTypes.Remove(value);
                    var typeSelectDialog = new TypeSelectDialog(AvailableTypes.ToList());
                    if (typeSelectDialog.ShowDialog() == true)
                    {
                        var selectedType = typeSelectDialog.SelectedType;
                        var complexFilterCreationDialog = new ComplexFilterCreationDialog(selectedType.GetModel());
                        if (complexFilterCreationDialog.ShowDialog() == true)
                        {
                            var filter = new ComplexFilter {Filters = complexFilterCreationDialog.Filters.ToList()};
                            Filters.Add(filter);
                            AvailableTypes.Remove(AvailableTypes.First(x => x.Name == selectedType.Name));
                        }

                    }
                    AvailableTypes.Add(value);
                }
                OnPropertyChanged("Filters");
                OnPropertyChanged("SelectedType");
                OnPropertyChanged("AvailableTypes");
            }
        }

        public ObservableCollection<BaseFilter> Filters { get; set; }
    }
}