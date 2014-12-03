using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Achievments;
using Achievments.AchievmentProperties;
using DataLayer;
using DataLayer.Repositories;

namespace CreateDatabase
{
    internal class CreateBaseDatabase
    {
        private static EnumPropertyType _levelPropertyType;
        private static EnumPropertyType _participantPropertyType;

        private static void Main(string[] args)
        {
            CreateLevelEnumPropertyType();
            CreateParticipantEnumPropertyType();
            
            var a = GetFirstAchievment();

            var b = GetSecondAchievment();

            AchievmentsRepository.GetInstance().AddRange(new List<Achievment>{a,b});
        }

        private static Achievment GetFirstAchievment()
        {

            var levelProperty = new EnumProperty
            {
                Type = _levelPropertyType,
                SelectedValue = _levelPropertyType.AvailibleValues.First()
            };


            var participantProperty = new EnumProperty
            {
                Type = _participantPropertyType,
                SelectedValue = _participantPropertyType.AvailibleValues.First()
            };

            var a = new Achievment()
            {
                EnumProperties = new List<EnumProperty>() {levelProperty, participantProperty}
            };
            return a;
        }

        private static Achievment GetSecondAchievment()
        {

            var levelProperty = new EnumProperty
            {
                Type = _levelPropertyType,
                SelectedValue = _levelPropertyType.AvailibleValues[1]
            };


            var participantProperty = new EnumProperty
            {
                Type = _participantPropertyType,
                SelectedValue = _participantPropertyType.AvailibleValues[1]
            };

            var a = new Achievment()
            {
                EnumProperties = new List<EnumProperty>() { levelProperty, participantProperty }
            };
            return a;
        }
        private static void CreateLevelEnumPropertyType()
        {
            var eptv = new EnumPropertyTypeValue() {Value = "Международный"};
            var eptv2 = new EnumPropertyTypeValue() {Value = "Городской"};
            _levelPropertyType = new EnumPropertyType()
            {
                AvailibleValues = new List<EnumPropertyTypeValue>() {eptv, eptv2},
                Name = "Уровень достижения"
            };
        }

        private static void CreateParticipantEnumPropertyType()
        {
            var eptv = new EnumPropertyTypeValue() { Value = "Участник" };
            var eptv2 = new EnumPropertyTypeValue() { Value = "Наблюдатель" };
            _participantPropertyType = new EnumPropertyType()
            {
                AvailibleValues = new List<EnumPropertyTypeValue>() { eptv, eptv2 },
                Name = "Тип участия"
            };

        }

    }
}
