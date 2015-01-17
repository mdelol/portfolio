﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Achievments;
using DataLayer.Repositories;
using VisualTestApp.Common;

namespace VisualTestApp.Achievments.Properties
{
    public class PropertiesViewModel : BaseViewModel
    {
        private PropertyViewModel _selectedProperty;

        public PropertiesViewModel()
        {
            List<Achievment> achievments = AchievmentsRepository.GetInstance().GetObjects();
            Properties = achievments.Select(x => x.Properties).First().Select(x=>new PropertyViewModel(x)).ToList();
        }

        public List<PropertyViewModel> Properties { get; set; }

        public PropertyViewModel SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value; 
                OnPropertyChanged("SelectedProperty");
            }
        }
    }
}