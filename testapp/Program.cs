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
using DataLayer;
using DataLayer.Repositories;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = AchievmentsRepository.GetInstance().GetObjects();
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
