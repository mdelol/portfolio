using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
using Microsoft.Win32;
using Models.Commands;

namespace OutputDocuments
{
    public class DocumentsCreator
    {

        public void FillDocument()
        {
            var chooseCommandWindow = new ChooseCommandWindow();

            chooseCommandWindow.Commands = new ObservableCollection<Command>(CommandsRepository.GetInstance().GetObjects());

            if (!chooseCommandWindow.ShowDialog() == true)
            {
                return;
            }

            var openFileDialog = new OpenFileDialog();
            if (!openFileDialog.ShowDialog() == true)
            {
                return;
            }

            var pathToFile = openFileDialog.FileName;

            var achievments = AchievmentsRepository.GetInstance().GetObjects();

            var dictionary = DbToFilter.Filter(achievments, chooseCommandWindow.SelectedCommands.ToList());
            Formatter.ReplaceTextInDocument(dictionary, pathToFile);
        }
    }
}
