using System;
using System.Collections.Generic;
using Models.Achievments;
using Models.Achievments.AchievmentProperties;
using VisualTestApp.Common;

namespace DatabaseVisualiser.Achievments.Properties.PropertyType
{
    public class PropertyTypeViewModel : BaseViewModel
    {
        private AchievmentPropertyType _model;
        private string _selectedType;

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
            Types = new Dictionary<string, string>
            {
                {"Строка", typeof (string).ToString()},
                {"Целочисленное значение", typeof (int).ToString()}
            };

            AchievmentTypes=new Dictionary<string, AchievmentType>
            {
                {AchievmentType.Publication.GetDescription(), (AchievmentType.Publication)},
                {AchievmentType.Other.GetDescription(), (AchievmentType.Other)},
                {AchievmentType.Publication.GetDescription() + ", " + AchievmentType.Other.GetDescription(), (AchievmentType.Publication | AchievmentType.Other)}
            };
        }

        public String Name
        {
            get
            {
                return _model.Name;
            }
            set
            {
                _model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public Dictionary<string, string> Types { get; set; }

        public string SelectedType
        {
            get { return _model.Type; }
            set { _model.Type = value; }
        }

        public AchievmentPropertyType GetModel()
        {
            return _model;
        }

        public Dictionary<string, AchievmentType> AchievmentTypes { get; set; }

        public AchievmentType ApplicableToTypes
        {
            get { return _model.ApplicableToTypes; }
            set
            {
                _model.ApplicableToTypes = value;
                OnPropertyChanged("ApplicableToTypes");
            }
        }
    }
}