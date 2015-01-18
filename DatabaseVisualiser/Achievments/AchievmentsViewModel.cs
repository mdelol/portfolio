using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using DatabaseVisualiser.Achievments.Properties;
using DataLayer;
using DataLayer.Repositories;
using Models.Achievments;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments
{
    public class AchievmentsViewModel : BaseViewModel
    {
        private AchievmentViewModel _selectedAchievment;

        public AchievmentsViewModel()
        {
            Achievments = new ObservableCollection<AchievmentViewModel>(AchievmentsRepository.GetInstance().GetObjects().Select(x => new AchievmentViewModel(x)));
            SelectedAchievment = Achievments.FirstOrDefault();
            DeletedAchievments=new List<AchievmentViewModel>();
        }

        public ObservableCollection<AchievmentViewModel> Achievments { get; set; }

        public List<AchievmentViewModel> DeletedAchievments { get; set; }

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

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    if (SelectedAchievment.GetModel().AchievmentId != 0)
                    {
                        DeletedAchievments.Add(SelectedAchievment);
                        Achievments.Remove(SelectedAchievment);
                        SelectedAchievment = Achievments.FirstOrDefault();
                    }
                    OnPropertyChanged("Achievments");
                });
            }
        }

        public IEnumerable<Achievment> GetModels()
        {
            return Achievments.Select(x => x.GetModel());
        }

    }
}