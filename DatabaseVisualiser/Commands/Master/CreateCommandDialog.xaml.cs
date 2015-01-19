using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DatabaseVisualiser.Achievments.Properties.PropertyType;
using DataLayer.Repositories;
using Models.Achievments.AchievmentProperties;
using Models.Commands.Filters;

namespace DatabaseVisualiser.Commands.Master
{
    /// <summary>
    /// Interaction logic for CreateCommandDialog.xaml
    /// </summary>
    public partial class CreateCommandDialog : Window
    {
        public CreateCommandDialog()
        {
            InitializeComponent();
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
