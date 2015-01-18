using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Commands;
using Commands.Filters;
using DataLayer;
using DataLayer.Repositories;
using Models.Achievments;
using Models.Achievments.AchievmentProperties;
using Models.Commands;
using Models.Commands.Filters;
using OutputDocuments;

namespace testapp
{
    /// <summary>
    /// тут тестируем
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var b = AchievmentsRepository.GetInstance().GetObjects();
            var a = PropertyTypesRepository.GetInstance().GetObjects().First();
            var f = new ExactFilter() { Type = a, ExactValue = "ololololo-lololo-lololo" };
            var g = new ExactFilter() {Type = a, ExactValue = "not funny at al"};
            var cf = new ComplexFilter() {Filters = new List<BaseFilter>() {f, g}};

            var command = new Command();
            command.Filters=new List<BaseFilter>()
            {
                cf
            };
            var result = command.Execute(b);
            var commandForFilter = new Command
            {
                Filters = new List<BaseFilter>()
                {
                    cf
                }
            };
            commandForFilter.Name = "myLittleCommand";
            List<Command> listCmd = new List<Command>();
            listCmd.Add(commandForFilter);

            // Jaroslaw test :)
            var resultOfFilter = DbToFilter.Filter(b, listCmd);
        }

        

        private static void testRead()
        {
            var a = new XmlSerializer(typeof (Achievment));
            var stream = new FileStream("C:/Users/Сергей/Desktop/test.xml", FileMode.Open);
            var b = (Achievment) a.Deserialize(stream);
            var t = Type.GetType(b.Properties.First().Type.Type);
        }

        private static void testWrite()
        {
            var APT = new AchievmentPropertyType() {Name = "testStringParameter", Type = typeof (string).AssemblyQualifiedName};
            var AP = new AchievmentProperty() {Type = APT, Value = "ololo"};
            var a = new Achievment()
            {
                Properties = new List<AchievmentProperty>() {AP},
                Type = AchievmentType.Publication
            };


            var va = new XmlSerializer(typeof (Achievment));
            var writer = new StreamWriter("C:/Users/Сергей/Desktop/test.xml");
            va.Serialize(writer, a);
        }
    }
}
