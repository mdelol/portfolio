using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseVisualiser.Achievments.Properties.PropertyType;
using DataLayer.Repositories;
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
            Filters=new ObservableCollection<BaseFilter>();
        }

        public string CommandName { get; set; }

        public bool UseAllAchievments { get; set; }

        public bool IsPublication { get; set; }

        public CommandViewModel SelectedCommand { get; set; }

        public List<CommandViewModel> AvailableCommands { get; set; }

        public ObservableCollection<PropertyTypeViewModel> AvailableTypes { get; set; }

        public PropertyTypeViewModel SelectedType
        {
            get { return null; }
            set
            {
                AvailableTypes.Remove(value);
                Filters.Add(new ExactFilter()
                {
                    Type = value.GetModel()
                });
                OnPropertyChanged("Filters");
            }
        }

        public ObservableCollection<BaseFilter> Filters { get; set; }
    }
}