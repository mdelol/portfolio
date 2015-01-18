using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Commands;
using DataLayer;
using DataLayer.Repositories;
using Commands.Filters;
using Models.Achievments;
using Models.Achievments.AchievmentProperties;
using Models.Commands;
using Models.Commands.Filters;

namespace CreateDatabase
{
    /// <summary>
    /// Создает начальную базу данных для проверки.
    /// </summary>
    internal class CreateBaseDatabase
    {
        private static AchievmentPropertyType _namePropertyTypeForPublic;
        private static AchievmentPropertyType _namePublisherPropertyTypeForPublic;
        private static AchievmentPropertyType _numOfPagesPropertyTypeForPublic;

        private static AchievmentPropertyType _nameEventPropertyTypeForOther;
        private static AchievmentPropertyType _nameWorkPropertyTypeForOther;

        private static void Main(string[] args)
        {
            var listAchievments = new List<Achievment>();
            CreateProperties();
            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));
            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));
            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));

            AchievmentsRepository.GetInstance().AddRange(listAchievments);

            var command = GetFirstCommand();

            CommandsRepository.GetInstance().AddObject(command);
        }

        private static Command GetFirstCommand()
        {
// Command to DB
            var command = new Command();
            var typeForFilter = PropertyTypesRepository.GetInstance().GetNoTrackingObjects().First();
            var f = new ExactFilter() {Type = typeForFilter, ExactValue = "2013"};
            var g = new ExactFilter() {Type = typeForFilter, ExactValue = "2014"};
            var cf = new ComplexFilter() {Filters = new List<BaseFilter>() {f, g}};
            command.Filters = new List<BaseFilter>()
            {
                cf
            };
            command.Name = "testCommand";
            return command;
        }

        private static void CreateProperties()
        {
            _namePropertyTypeForPublic = new AchievmentPropertyType() { Name = "Название публикации", Type = typeof(string).ToString(), ApplicableToTypes = AchievmentType.Publication };
            _namePublisherPropertyTypeForPublic = new AchievmentPropertyType() { Name = "Название издательства", Type = typeof(string).ToString(), ApplicableToTypes = AchievmentType.Publication};
            _numOfPagesPropertyTypeForPublic = new AchievmentPropertyType() { Name = "Количество страниц", Type = typeof(int).ToString(), ApplicableToTypes = AchievmentType.Publication};

            _nameEventPropertyTypeForOther = new AchievmentPropertyType() { Name = "Наименование мероприятия", Type = typeof(string).ToString(), ApplicableToTypes = AchievmentType.Other};
            _nameWorkPropertyTypeForOther = new AchievmentPropertyType() { Name = "Наименование выполняемой работы", Type = typeof(string).ToString(), ApplicableToTypes = AchievmentType.Other};

            PropertyTypesRepository.GetInstance().AddRange(new List<AchievmentPropertyType> { 
                _namePropertyTypeForPublic,
                _namePublisherPropertyTypeForPublic,
                _numOfPagesPropertyTypeForPublic,
                _nameEventPropertyTypeForOther,
                _nameWorkPropertyTypeForOther
            });
        }
    }
}
