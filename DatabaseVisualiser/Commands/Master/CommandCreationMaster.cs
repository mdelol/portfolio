using System.Linq;
using Models.Commands;

namespace DatabaseVisualiser.Commands.Master
{
    public class CommandCreationMaster
    {
        public CommandViewModel CreateCommand()
        {
            var createCommandDialog = new CreateCommandDialog();
            var newCommandViewModel = new NewCommandViewModel();
            createCommandDialog.DataContext = newCommandViewModel;
            if (createCommandDialog.ShowDialog() == true)
            {
                var command = new Command()
                {
                    Filters = newCommandViewModel.Filters.ToList(),
                    Name = newCommandViewModel.CommandName
                };
                command.ParentCommand = newCommandViewModel.UseAllAchievments ? null : newCommandViewModel.SelectedCommand.GetModel();
                var viewModel = new CommandViewModel(command);
                return viewModel;
            }
            return null;
        }
    }
}