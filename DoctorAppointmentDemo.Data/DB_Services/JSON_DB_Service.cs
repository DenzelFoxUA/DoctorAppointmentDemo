using MyDoctorAppointment.Data.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MyDoctorAppointment.Domain.Interfaces;
using DoctorAppointmentDemo.Data.DB_Services;

namespace MyDoctorAppointment.Data.DB_Services
{

    public class JSON_DB_Service : IManageDB_Sources
    {
        
        public void ModifyId(DB_Entities entitiy, int value)
        {
            JObject obj = JObject.Parse(File.ReadAllText(MyConstants.JSON_DB_SETTINGS_PATH));
            var dataBase = (JObject)obj[MyConstants.DB_NAME]!;
            var entityData = (JObject)dataBase[entitiy.ToString()]!;
            entityData.Property("LastId")!.Value = value;
            WriteToJSON(MyConstants.JSON_DB_SETTINGS_PATH, obj);
        }

        public IEnumerable<T> ReadAll<T>(string path, DB_Entities rootName = DB_Entities.None) where T : IAuditable<T>
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            var json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<T>>(json)!;
        }

        public void AppendObjectToBase<T>(string path, T obj, DB_Entities rootName = DB_Entities.None) where T : IAuditable<T>
        {
            if (File.Exists(path) == true && obj is not null)
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(ReadAll<T>(path).Append(obj), Formatting.Indented));
            }
        }

        public bool UpdateObject<T>(string path, T obj, int objId, DB_Entities rootName = DB_Entities.None) where T : IAuditable<T>
        {
            if (File.Exists(path) == true && obj is not null)
            {
                File.WriteAllText(path,
                JsonConvert.SerializeObject(ReadAll<T>(path).Select(x => x.Id == objId ? obj : x),
                Newtonsoft.Json.Formatting.Indented));
                return true;
            }
            else return false;
                
        }

        public bool RemoveFromDB<T>(string path, int id, DB_Entities rootName = DB_Entities.None) where T : IAuditable<T>
        {
            if (File.Exists(path) == true)
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(ReadAll<T>(path).Where(x => x.Id != id),
                Newtonsoft.Json.Formatting.Indented));
                return true;
            }
            else return false;
        }

        public static void WriteToJSON(string filePath, JObject modified)
        {
           if (File.Exists(filePath) == true && modified is not null)
           {
                using (StreamWriter file = File.CreateText(filePath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    modified.WriteTo(writer);
                }
            }
            
        }

        public T GetById<T>(string path, int id,
            DB_Entities rootName = DB_Entities.None) where T: IAuditable<T>
        {
            if(File.Exists(path) == true)
            {
                return ReadAll<T>(path).FirstOrDefault(x => x.Id == id)!;
            }
            return default!;
        }
    }

}
