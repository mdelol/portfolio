using System.Windows;

namespace DatabaseVisualiser.Achievments.Properties.PropertyType
{
    /// <summary>
    /// Interaction logic for PropertyTypesView.xaml
    /// </summary>
    public partial class PropertyTypesView : Window
    {
        public PropertyTypesView()
        {
            InitializeComponent();
        }

        private void Ok_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
