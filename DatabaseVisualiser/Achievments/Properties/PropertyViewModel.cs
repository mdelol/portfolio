using System;
using Models.Achievments.AchievmentProperties;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments.Properties
{
    public class PropertyViewModel : BaseViewModel
    {
        private AchievmentProperty _model;
        private object _value;

        public PropertyViewModel(AchievmentProperty model)
        {
            _model = model;
            Name = _model.Type.Name;
            _value = model.Value;
        }

        public string Value
        {
            get
            {
                return _model.Value;
            }
            set
            {
                _value = Convert.ChangeType(value, Type.GetType(_model.Type.Type));
                _model.Value = Convert.ToString(_value);
            }
        }

        public string Name { get; set; }
    }
}