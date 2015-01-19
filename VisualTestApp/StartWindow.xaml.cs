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
using System.Windows.Shapes;
using DatabaseVisualiser;

namespace VisualTestApp
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void ExportButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void ShowCommands(object sender, RoutedEventArgs e)
        {
            new DbVisualizer().ShowCommands();
        }

        private void ShowAchievments(object sender, RoutedEventArgs e)
        {
            new DbVisualizer().ShowAchievments();
        }

        private void ShowPropertyTypes(object sender, RoutedEventArgs e)
        {
            new DbVisualizer().ShowPropertyTypes();
        }
    }
}
