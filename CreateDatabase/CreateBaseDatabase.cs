using System.Collections.Generic;
using Achievments;
using Achievments.AchievmentProperties;
using DataLayer;
using DataLayer.Repositories;

namespace CreateDatabase
{
    internal class CreateBaseDatabase
    {
        private static void Main(string[] args)
        {
            var eptv = new EnumPropertyTypeValue() {Value = "Международный"};
            var eptv2 = new EnumPropertyTypeValue() {Value = "Городской"};
            var ept = new EnumPropertyType()
            {
                AvailibleAValues = new List<EnumPropertyTypeValue>() {eptv, eptv2},
                Name = "Уровень достижения"
            };
            var ep = new EnumProperty()
            {
                Type = ept,
                SelectedValue = eptv
            };
            var a = new Achievment()
            {
                EnumProperties = new List<EnumProperty>() {ep}
            };

            AchievmentsRepository.GetInstance().AddObject(a);
        }
    }
}
