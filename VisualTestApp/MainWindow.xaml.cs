using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Repositories;
using VisualTestApp.Achievments.Properties;
using VisualTestApp.Achievments.Properties.PropertyType;

namespace VisualTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var propertyTypesViewModel = new PropertyTypesViewModel();
            var window = new PropertyTypesView()
            {
                DataContext = propertyTypesViewModel
            };
            window.ShowDialog();
            //if (window.ShowDialog() == true)
            {
                var propertyTypesRepository = PropertyTypesRepository.GetInstance();
                foreach (var achievmentPropertyType in propertyTypesViewModel.GetModels())
                {
                    propertyTypesRepository.UpdateOrAddObject(achievmentPropertyType);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new PropertiesView()
            {
                DataContext = new PropertiesViewModel()
            };
            window.ShowDialog();
        }
    }
}
