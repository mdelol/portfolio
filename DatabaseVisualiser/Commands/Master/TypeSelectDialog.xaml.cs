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
using DatabaseVisualiser.Achievments.Properties.PropertyType;

namespace DatabaseVisualiser.Commands.Master
{
    /// <summary>
    /// Interaction logic for TypeSelectDialog.xaml
    /// </summary>
    public partial class TypeSelectDialog : Window
    {
        public TypeSelectDialog(IEnumerable<PropertyTypeViewModel> properties)
        {
            InitializeComponent();
            DataContext = this;
            AvailableTypes = properties;
            SelectedType = AvailableTypes.FirstOrDefault();
        }

        public IEnumerable<PropertyTypeViewModel> AvailableTypes { get; set; }

        public PropertyTypeViewModel SelectedType { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
