using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.DB_Services;
using MyDoctorAppointment.Domain.Interfaces;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Data.DB_Services
{

    public static class XML_Extentions
    { 
        public static XElement Get_XElement<T>(this T obj) where T : IAuditable<T>
        {
            string xml = string.Empty;
            using (StringWriter ms = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(ms, obj);
                xml = ms.ToString();
            }

            return XElement.Parse(xml);
        }

        public static T LoadFromXMLString<T>(string xmlText) where T : class, IAuditable<T>
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stringReader) as T;
            }
        }


    }


    public class XML_DB_Service : IDB_Service
    {
        public static void ModifyId(DB_Entities entitiy, int value)
        {
            JObject obj = JObject.Parse(File.ReadAllText(MyConstants.XML_DB_SETTINGS_PATH));
            var dataBase = (JObject)obj[MyConstants.DB_NAME]!;
            var entityData = (JObject)dataBase[entitiy.ToString()]!;
            entityData.Property("LastId")!.Value = value;
            JSON_DB_Service.WriteToJSON(MyConstants.XML_DB_SETTINGS_PATH, obj);
        }

        public static IEnumerable<T> ReadAll<T>(string path, DB_Entities rootName) where T : IAuditable<T>
        {
            var tCollection = new List<T>();

            if (File.Exists(path) == true)
            {
                XDocument doc = XDocument.Load(path);
                XElement? xRoot = doc.Element(rootName.ToString());
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                if (xRoot is not null)
                {
                    foreach (var xElement in xRoot.Elements())
                    {
                        var item = xmlSerializer.Deserialize(xElement.CreateReader());
                        tCollection.Add((T)item);
                    }

                    return tCollection;
                }
                
            }

            return default!;
        }

        public static void AppendObjectToBase<T>(string filePath, T element, DB_Entities rootName) where T : IAuditable<T>
        {
            if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument();
                XElement root = new XElement(rootName.ToString());
                doc.Add(root);

                if (root != null)
                {
                    root.Add(element.Get_XElement());

                    doc.Save(filePath);

                }
            }
            else
            {
                XDocument xdoc = XDocument.Load(filePath);
                XElement? root = xdoc.Element(rootName.ToString());

                if (root != null)
                {
                    root.Add(element.Get_XElement());

                    xdoc.Save(filePath);
                }

            }
        }

        public static bool RemoveFromDB<T>(string path, int id, DB_Entities rootName) where T : IAuditable<T>
        {
            if (File.Exists(path) == true)
            {
                XDocument xdoc = XDocument.Load(path);
                XElement? root = xdoc.Element(rootName.ToString());
                
                if (root != null)
                {
                    var element = root.Elements(typeof(T).Name)
                        .FirstOrDefault(p => p.Element("Id")?.Value == id.ToString());
                    if (element != null)
                    {
                        element.Remove();
                        xdoc.Save(path);
                        return true;
                    }

                }
            }
            return false;
        }

        public static bool UpdateObject<T>(string path, T objectChanged, int id, DB_Entities rootName) where T : IAuditable<T>
        {
            bool found = RemoveFromDB<T>(path, id, rootName);

            if(found is true)
            {
                AppendObjectToBase(path, objectChanged, rootName);
            }

            return found;

        }

        public static T GetById<T>(string path, int id, DB_Entities rootName) where T : IAuditable<T>
        {
            if (File.Exists(path) == true)
            {
                XDocument xdoc = XDocument.Load(path);

                var element = xdoc.Elements(typeof(T).Name).FirstOrDefault(p => p.Attribute("Id")?.Value == id.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                if (element is not null)
                {
                    return (T)serializer.Deserialize(element.CreateReader())!;
                }

                    
            }
            return default!;
        }
    }
}
