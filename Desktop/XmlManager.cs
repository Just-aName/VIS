using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Desktop
{
    public static class XmlManager
    {
        private static string mealFilename = "E:\\C#\\VIS\\confirmMeal.xml";
        private static string activityFilename = "E:\\C#\\VIS\\confirmActivity.xml";
        private static XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

        public static List<int> MealIdList = new List<int>();
        public static List<int> ActivityIdList = new List<int>();

        public static void ReadMealXml()
        {
            var document = XDocument.Load(mealFilename);
            var data = document.Root.Elements().Select(x => int.Parse(x.Value)).ToList();
            MealIdList.AddRange(data);
        }

        public static void ReadActivityXml()
        {
            var document = XDocument.Load(activityFilename);
            var data = document.Root.Elements().Select(x => int.Parse(x.Value)).ToList();
            ActivityIdList.AddRange(data);
        }

        public static void WriteMealXml()
        {
            var doc = new XDocument(new XElement("List", MealIdList.Select(x =>
                      new XElement("int", x))));
            doc.Save(mealFilename);
        }

        public static void WriteActivityXml()
        {
            var doc = new XDocument(new XElement("List", ActivityIdList.Select(x =>
                      new XElement("int", x))));
            doc.Save(activityFilename);
        }

        public static void RemoveMealId(int id)
        {
            MealIdList.Remove(id);
        }

        public static void RemoveActivityId(int id)
        {
            ActivityIdList.Remove(id);
        }
    }
}
