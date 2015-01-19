using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using DatabaseVisualiser.Achievments;
using DatabaseVisualiser.Achievments.Properties.PropertyType;
using DatabaseVisualiser.Commands;
using DataLayer.Repositories;
using Microsoft.Win32;
using Models.Commands;
using OutputDocuments;

namespace DatabaseVisualiser
{
    public class DbVisualizer
    {
        public void ShowPropertyTypes()
        {
            var propertyTypesViewModel = new PropertyTypesViewModel();
            var window = new PropertyTypesView()
            {
                DataContext = propertyTypesViewModel
            };
            window.ShowDialog();

            var propertyTypesRepository = PropertyTypesRepository.GetInstance();
            var models = propertyTypesViewModel.GetModels();
            foreach (var propertyType in models)
            {
                propertyTypesRepository.UpdateOrAddObject(propertyType);
            }

            var deletedViewModels = propertyTypesViewModel.DeletedViewModels;
            foreach (var achievmentPropertyType in deletedViewModels)
            {
                propertyTypesRepository.DeleteObject(achievmentPropertyType.GetModel());
            }
        }

        public void ShowAchievments()
        {
            var achievmentsViewModel = new AchievmentsViewModel(AchievmentsRepository.GetInstance().GetObjects());
            var window = new AchievmentsView()
            {
                DataContext = achievmentsViewModel
            };
            window.ShowDialog();

            var achievmentsRepository = AchievmentsRepository.GetInstance();
            var models = achievmentsViewModel.GetModels();
            foreach (var achievment in models)
            {
                achievmentsRepository.UpdateOrAddObject(achievment);
            }

            var deletedViewModels = achievmentsViewModel.DeletedAchievments;
            foreach (var achievmentViewModel in deletedViewModels)
            {
                achievmentsRepository.DeleteObject(achievmentViewModel.GetModel());
            }
        }

        public void ShowCommands()
        {
            var commandsViewModel = new CommandsViewModel();
            var window = new CommandsView()
            {
                DataContext = commandsViewModel
            };
            window.ShowDialog();

            var repository = CommandsRepository.GetInstance();
            var models = commandsViewModel.GetModels();
            foreach (var command in models)
            {
                repository.UpdateOrAddObject(command);
            }

            var deletedCommands = commandsViewModel.DeletedCommands.Select(x => x.GetModel());
            foreach (var deletedCommand in deletedCommands)
            {
                repository.DeleteObject(deletedCommand);
            }
        }
    }
}
