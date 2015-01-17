using System;
using System.Collections.Generic;
using Achievments.AchievmentProperties;
using VisualTestApp.Common;

namespace VisualTestApp.Achievments.Properties.PropertyType
{
    public class PropertyTypeViewModel : BaseViewModel
    {
        private AchievmentPropertyType _model;

        public PropertyTypeViewModel(AchievmentPropertyType model)
            : this()
        {
            _model = model;
            Name = _model.Name;
            SelectedType = _model.Type;
            OnPropertyChanged("SelectedType");
        }

        public PropertyTypeViewModel()
        {
            Types = new Dictionary<string, string>();
            Types.Add("Строка", typeof(string).ToString());
            Types.Add("Целочисленное значение", typeof(int).ToString());
        }

        public String Name { get; set; }

        public Dictionary<string, string> Types { get; set; }

        public string SelectedType { get; set; }
    }
}