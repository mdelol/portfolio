using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Achievments;
using DatabaseVisualiser.Achievments.Properties;
using DataLayer;
using DataLayer.Repositories;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments
{
    public class AchievmentsViewModel:BaseViewModel
    {
        private AchievmentViewModel _selectedAchievment;

        public AchievmentsViewModel()
        {
            Achievments = new ObservableCollection<AchievmentViewModel>(AchievmentsRepository.GetInstance().GetObjects().Select(x=>new AchievmentViewModel(x)));
            SelectedAchievment = Achievments.FirstOrDefault();
        }

        public ObservableCollection<AchievmentViewModel> Achievments{ get; set; }

        public AchievmentViewModel SelectedAchievment
        {
            get { return _selectedAchievment; }
            set
            {
                _selectedAchievment = value;
                OnPropertyChanged("SelectedAchievment");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(x =>
                {
                    var dialog = new TypeChooseDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        Achievments.Add(new AchievmentViewModel(AchievmentsFactory.GetEmptyAchievment(dialog.SelectedType)));
                    }
                });
            }

        }

    }
}