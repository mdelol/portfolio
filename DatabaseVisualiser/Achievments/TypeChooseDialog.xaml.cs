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
using Achievments;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments
{
    /// <summary>
    /// Interaction logic for TypeChooseDialog.xaml
    /// </summary>
    public partial class TypeChooseDialog : Window
    {
        public TypeChooseDialog()
        {
            InitializeComponent();
            DataContext = this;

            AchievmentTypes = new Dictionary<string, AchievmentType>
            {
                {AchievmentType.Publication.GetDescription(), (AchievmentType.Publication)},
                {AchievmentType.Other.GetDescription(), (AchievmentType.Other)}
            };
            SelectedType = AchievmentTypes.First().Value;

        }

        public Dictionary<string, AchievmentType> AchievmentTypes { get; set; }

        public AchievmentType SelectedType { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
