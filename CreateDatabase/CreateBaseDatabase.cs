using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Achievments;
using Achievments.AchievmentProperties;
using Commands;
using DataLayer;
using DataLayer.Repositories;

namespace CreateDatabase
{
    /// <summary>
    /// Создает начальную базу данных для проверки.
    /// </summary>
    internal class CreateBaseDatabase
    {
        private static EnumPropertyType _levelEnumPropertyType;
        private static EnumPropertyType _participantEnumPropertyType;
        private static AchievmentPropertyType _yearPropertyType;
        private static AchievmentPropertyType _namePropertyType;

        private static void Main(string[] args)
        {
            CreateLevelEnumPropertyType();
            CreateParticipantEnumPropertyType();
            CreateYearPropertyType();
            СreateNamePropertyType();

            var a = GetFirstAchievment();

            var b = GetSecondAchievment();

            AchievmentsRepository.GetInstance().AddRange(new List<Achievment> { a, b });

            var command = new Command();
            command.Name = "testCommand";

        }

        private static Achievment GetFirstAchievment()
        {

            var levelProperty = new EnumProperty
            {
                Type = _levelEnumPropertyType,
                SelectedValue = _levelEnumPropertyType.AvailibleValues.First()
            };


            var participantProperty = new EnumProperty
            {
                Type = _participantEnumPropertyType,
                SelectedValue = _participantEnumPropertyType.AvailibleValues.First()
            };

            var nameProperty = new AchievmentProperty() { Type = _namePropertyType, Value = "ololololo-lololo-lololo" };
            var yearProperty = new AchievmentProperty() { Type = _yearPropertyType, Value = "2014" };
            var a = new Achievment()
            {
                EnumProperties = new List<EnumProperty>() { levelProperty, participantProperty },
                Properties = new List<AchievmentProperty>() { nameProperty, yearProperty }
            };
            return a;
        }

        private static Achievment GetSecondAchievment()
        {

            var levelProperty = new EnumProperty
            {
                Type = _levelEnumPropertyType,
                SelectedValue = _levelEnumPropertyType.AvailibleValues[1]
            };


            var participantProperty = new EnumProperty
            {
                Type = _participantEnumPropertyType,
                SelectedValue = _participantEnumPropertyType.AvailibleValues[1]
            };

            var nameProperty = new AchievmentProperty() { Type = _namePropertyType, Value = "not funny at all" };
            var yearProperty = new AchievmentProperty() { Type = _yearPropertyType, Value = "2013" };

            var a = new Achievment()
            {
                EnumProperties = new List<EnumProperty>() { levelProperty, participantProperty },
                Properties = new List<AchievmentProperty>() { nameProperty, yearProperty }
            };
            return a;
        }
        private static void CreateLevelEnumPropertyType()
        {
            var eptv = new EnumPropertyTypeValue() { Value = "Международный" };
            var eptv2 = new EnumPropertyTypeValue() { Value = "Городской" };
            _levelEnumPropertyType = new EnumPropertyType()
            {
                AvailibleValues = new List<EnumPropertyTypeValue>() { eptv, eptv2 },
                Name = "Уровень достижения"
            };
        }

        private static void CreateParticipantEnumPropertyType()
        {
            var eptv = new EnumPropertyTypeValue() { Value = "Участник" };
            var eptv2 = new EnumPropertyTypeValue() { Value = "Наблюдатель" };
            _participantEnumPropertyType = new EnumPropertyType()
            {
                AvailibleValues = new List<EnumPropertyTypeValue>() { eptv, eptv2 },
                Name = "Тип участия"
            };

        }

        private static void CreateYearPropertyType()
        {
            _yearPropertyType = new AchievmentPropertyType() { Name = "Год", Type = typeof(int).ToString(), ApplicableToTypes = AchievmentType.Other};
        }

        private static void СreateNamePropertyType()
        {
            _namePropertyType = new AchievmentPropertyType() { Name = "Имя", Type = typeof(string).ToString(), ApplicableToTypes = AchievmentType.Other };
        }
    }
}
