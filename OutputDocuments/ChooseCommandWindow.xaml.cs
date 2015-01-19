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
using DataLayer.Repositories;
using Models.Commands;

namespace OutputDocuments
{
    /// <summary>
    /// Interaction logic for ChooseCommandWindow.xaml
    /// </summary>
    public partial class ChooseCommandWindow : Window
    {
        public ChooseCommandWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<Command> Commands { get; set; }

        public IEnumerable<Command> SelectedCommands
        {
            get { return CommandsListView.SelectedItems.Cast<Command>(); }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
