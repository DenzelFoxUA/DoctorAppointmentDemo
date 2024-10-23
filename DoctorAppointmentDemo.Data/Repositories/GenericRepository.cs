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

        public DB_Entities EntityName { get; init; } // enum перечислення сутностей в структурі БД

        public IManageDB_Sources IDBService { get; init; }

        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            IDBService.AppendObjectToBase(Path, source, EntityName);
            
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {

            if (GetById(id) is null)
                return false;

                IDBService.RemoveFromDB<TSource>(Path, id,EntityName);
                
            return true;

        }

        public IEnumerable<TSource> GetAll()
        {
            
            return IDBService.ReadAll<TSource>(Path, EntityName);

        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            IDBService.UpdateObject(Path, source, id, EntityName);
            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected void SaveLastId()
        {
            
            IDBService.ModifyId(EntityName, LastId);

        }

        protected DB_Root DB_AppSettings(string db_settingsPath) 
            => JsonConvert.DeserializeObject<DB_Root>(File.ReadAllText(db_settingsPath))!;

    }

}
