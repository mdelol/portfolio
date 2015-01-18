using System;
using System.CodeDom;
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

            // Create abstract properties for Achiev types - publication and other
            CreateProperties();

            // Create concrete achievments with concrete properties

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            FillProperty(listAchievments[0], _namePropertyTypeForPublic, "Трактат о пользе пивного брюшка в проектировании программного обеспечения");
            FillProperty(listAchievments[0], _namePublisherPropertyTypeForPublic, "Том-книга");
            FillProperty(listAchievments[0], _numOfPagesPropertyTypeForPublic, "42");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            FillProperty(listAchievments[1], _namePropertyTypeForPublic, "Песенник для шестиструнной гитары PHP-разработчиков");
            FillProperty(listAchievments[1], _namePublisherPropertyTypeForPublic, "МосИздатМукулатура имени Ленина");
            FillProperty(listAchievments[1], _numOfPagesPropertyTypeForPublic, "1982");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            FillProperty(listAchievments[2], _namePropertyTypeForPublic, "Анекдот про Вовочку");
            FillProperty(listAchievments[2], _namePublisherPropertyTypeForPublic, "КомедиКлабПресс");
            FillProperty(listAchievments[2], _numOfPagesPropertyTypeForPublic, "42");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            FillProperty(listAchievments[3], _namePropertyTypeForPublic, "Анекдот про Петечку");
            FillProperty(listAchievments[3], _namePublisherPropertyTypeForPublic, "КомедиКлабПресс");
            FillProperty(listAchievments[3], _numOfPagesPropertyTypeForPublic, "10");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Publication));
            FillProperty(listAchievments[4], _namePropertyTypeForPublic, "Анекдот про Сережу");
            FillProperty(listAchievments[4], _namePublisherPropertyTypeForPublic, "КомедиКлабПресс");
            FillProperty(listAchievments[4], _numOfPagesPropertyTypeForPublic, "1982");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));
            FillProperty(listAchievments[5], _nameEventPropertyTypeForOther, "Катание на сноубордах");
            FillProperty(listAchievments[5], _nameWorkPropertyTypeForOther, "Сказ о том, как я за один час 15 метров проехал");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));
            FillProperty(listAchievments[6], _nameEventPropertyTypeForOther, "Встреча мэра с детсадовцами");
            FillProperty(listAchievments[6], _nameWorkPropertyTypeForOther, "Лекции о расточительстве и распиле госсердств. Пособие для молодежи дошкольного возраста");

            listAchievments.Add(AchievmentsFactory.GetEmptyAchievment(AchievmentType.Other));
            FillProperty(listAchievments[7], _nameEventPropertyTypeForOther, "Просмотр нового Хоббита");
            FillProperty(listAchievments[7], _nameWorkPropertyTypeForOther, "Как увеличить соотношение страниц на минуту экранного времени, чтобы все были счастливы");

            AchievmentsRepository.GetInstance().AddRange(listAchievments);

            //var command = GetFirstCommand();

            // Create commands for testing
            var command = new Command();
            var typeForFilter = PropertyTypesRepository.GetInstance().GetObjects().First(a => a == _numOfPagesPropertyTypeForPublic);
            var f = new ExactFilter() { Type = typeForFilter, ExactValue = "42" };
            var g = new ExactFilter() { Type = typeForFilter, ExactValue = "1982" };
            var cf = new ComplexFilter() { Filters = new List<BaseFilter>() { f, g } };
            command.Filters = new List<BaseFilter>()
            {
                cf
            };
            command.Name = "cmdTake__Prop_NumPages__With_42and1982";
            CommandsRepository.GetInstance().AddObject(command);

            command = new Command();
            typeForFilter = PropertyTypesRepository.GetInstance().GetObjects().First(a => a == _namePublisherPropertyTypeForPublic);
            f = new ExactFilter() { Type = typeForFilter, ExactValue = "КомедиКлабПресс" };
            cf = new ComplexFilter() { Filters = new List<BaseFilter>() { f } };
            command.Filters = new List<BaseFilter>()
            {
                cf
            };
            command.Name = "cmdTake__Prop_NamePublisher__With_ComedyClubPress";
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

        public static void FillProperty(Achievment achievment, AchievmentPropertyType achievmentPropertyType, string value)
        {
            achievment.Properties.First(a => a.Type == achievmentPropertyType).Value = value;
        }
    }
}
