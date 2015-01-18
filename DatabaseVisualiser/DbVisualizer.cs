using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using DatabaseVisualiser.Achievments;
using DatabaseVisualiser.Achievments.Properties.PropertyType;
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
            var achievmentsViewModel = new AchievmentsViewModel();
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

        public void ShitHappender()
        {
            var openFileDialog = new OpenFileDialog();
            var achievments = AchievmentsRepository.GetInstance().GetObjects();
            var command = CommandsRepository.GetInstance().GetObjects().First();
            var commandList = new List<Command>();
            commandList.Add(command);
            string pathToFile="";
            if (openFileDialog.ShowDialog()==true)
            {
                pathToFile = openFileDialog.FileName;
            }
            var dictionary = DbToFilter.Filter(achievments, commandList);
            Formatter.ReplaceTextInDocument(dictionary,pathToFile);
        }
    }
}
