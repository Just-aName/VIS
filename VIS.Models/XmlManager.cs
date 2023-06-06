using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace VIS.Models
{
    public class XmlManager
    {
        private string mealFilename = "E:\\C#\\VIS\\confirmMeal.xml";
        private string activityFilename = "E:\\C#\\VIS\\confirmActivity.xml";

        public XmlManager()
        {

        }

        public void AddMeal(int id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            List<int> data = new List<int>();
            using (FileStream stream = new FileStream(mealFilename, FileMode.OpenOrCreate))
            {
                data.AddRange((List<int>)serializer.Deserialize(stream));
            }

            data.Add(id);

            using (FileStream stream = File.OpenWrite(mealFilename))
            {
                serializer.Serialize(stream, data);
            }
        }

        public void AddActivity(int id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            List<int> data = new List<int>();
            using (FileStream stream = new FileStream(activityFilename, FileMode.OpenOrCreate))
            {
                data.AddRange((List<int>)serializer.Deserialize(stream));
            }

            data.Add(id);

            using (FileStream stream = File.OpenWrite(activityFilename))
            {
                serializer.Serialize(stream, data);
            }
        }
    }
}