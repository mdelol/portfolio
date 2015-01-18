using DatabaseVisualiser.Achievments;
using DatabaseVisualiser.Achievments.Properties.PropertyType;
using DataLayer.Repositories;

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
            var viewModels = propertyTypesViewModel.GetModels();
            foreach (var achievmentPropertyType in viewModels)
            {
                propertyTypesRepository.UpdateOrAddObject(achievmentPropertyType);
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


        }
    }
}
