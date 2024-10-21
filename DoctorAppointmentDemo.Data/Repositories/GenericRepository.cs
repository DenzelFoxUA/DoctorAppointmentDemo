using MyDoctorAppointment.Domain.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using Newtonsoft.Json;
using DoctorAppointmentDemo.Data.DB_Services;
using MyDoctorAppointment.Data.DB_Services;
using static DoctorAppointmentDemo.Data.DB_Services.DB_DataStructure;

namespace MyDoctorAppointment.Data.Repositories
{
    //базовий дженерік клас, який є основою всих репозиторіїв, та працює з всімо обєктами що реалізують інтерфейс IAuditable<>
    // за допомогою світч міняє сервіси джерел БД
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : IAuditable<TSource>
    {
        public SourceDB SourceDB { get; init; } // enum перечислення доступних джерел БД

        public DB_Entities EntityName { get; init; } // enum перечислення сутностей в структурі БД

        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            switch (SourceDB)
            {
                case SourceDB.JSON: JSON_DB_Service.AppendObjectToBase(Path, source); break;
                case SourceDB.XML: XML_DB_Service.AppendObjectToBase<TSource>(Path, source, EntityName); break;
            }
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {

            if (GetById(id) is null)
                return false;

            switch (SourceDB)
            {
                case SourceDB.JSON: JSON_DB_Service.RemoveFromDB<TSource>(Path, id); break;
                case SourceDB.XML: XML_DB_Service.RemoveFromDB<TSource>(Path, id, EntityName); break;
            }
            return true;

        }

        public IEnumerable<TSource> GetAll()
        {
            switch (SourceDB)
            {
                case SourceDB.JSON: return JSON_DB_Service.ReadAll<TSource>(Path);
                case SourceDB.XML: return XML_DB_Service.ReadAll<TSource>(Path, EntityName);
                case SourceDB.SQL: break;
                default: break;
            }
            return default!;
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            switch (SourceDB)
            {
                case SourceDB.JSON: JSON_DB_Service.UpdateObject(Path, source, id); break;
                case SourceDB.XML: XML_DB_Service.UpdateObject(Path, source, id, EntityName); break;
            }

            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected void SaveLastId()
        {
            switch (SourceDB)
            {
                case SourceDB.JSON: JSON_DB_Service.ModifyId(EntityName, LastId); break;
                case SourceDB.XML: XML_DB_Service.ModifyId(EntityName, LastId); break;
            }
        }

        protected DB_Root DB_AppSettings(string db_settingsPath) 
            => JsonConvert.DeserializeObject<DB_Root>(File.ReadAllText(db_settingsPath))!;

    }

}
