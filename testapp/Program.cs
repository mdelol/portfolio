using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Achievments;
using Achievments.AchievmentProperties;
using Commands;
using Commands.Filters;
using DataLayer;
using DataLayer.Repositories;

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
