using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DatabaseVisualiser.Achievments;
using DatabaseVisualiser.Commands.Master;
using DataLayer.Repositories;
using Models.Commands;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Commands
{
    public class CommandsViewModel : BaseViewModel
    {
        private CommandViewModel _selectedCommand;

        public CommandsViewModel()
        {
            var com = CommandsRepository.GetInstance().GetObjects();
            Commands = new ObservableCollection<CommandViewModel>(com.Select(x => new CommandViewModel(x)));
            DeletedCommands=new ObservableCollection<CommandViewModel>();
            SelectedCommand = Commands.FirstOrDefault();
        }

        public ObservableCollection<CommandViewModel> Commands { get; set; }

        public ObservableCollection<CommandViewModel> DeletedCommands { get; set; }

        public CommandViewModel SelectedCommand
        {
            get { return _selectedCommand; }
            set
            {
                _selectedCommand = value;
                OnPropertyChanged("SelectedCommand");
                OnPropertyChanged("SelectedCommand.Filters");
                OnPropertyChanged("Filters");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(x =>
                {
                    var commandViewModel = new CommandCreationMaster().CreateCommand();
                    if (commandViewModel != null)
                    {
                        Commands.Add(commandViewModel);
                    }
                });
            }
        }

        public ICommand ExecuteCurrent
        {
            get
            {
                return new RelayCommand(x =>
                {
                    var achiev = AchievmentsRepository.GetInstance().GetObjects();
                    var achievments = SelectedCommand.GetModel().Execute(achiev);
                    var achievmentsViewModel = new AchievmentsViewModel(achievments, true);
                    var dialog = new AchievmentsView()
                    {
                        DataContext = achievmentsViewModel
                    };
                    dialog.ShowDialog();
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(x =>
                {
                    if (SelectedCommand.GetModel().CommandId != 0)
                    {
                        DeletedCommands.Add(SelectedCommand);
                    }
                    var index = Commands.IndexOf(SelectedCommand);
                    Commands.Remove(SelectedCommand);
                    if (Commands.Count == 0)
                    {
                        SelectedCommand = null;
                        return;
                    }
                    SelectedCommand = index == 0 ? Commands[0] : Commands[index - 1];
                });
            }
        }

        public IEnumerable<Command> GetModels()
        {
            return Commands.Select(x => x.GetModel());
        }
    }
}