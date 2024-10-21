using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Interfaces;

namespace DoctorAppointmentDemo.Data.DB_Services
{

    //інтерфейс, який повинні реалізувати всі сервіси, що керують потоком даних в БД
    public interface IDB_Service
    {
        public static abstract void ModifyId(DB_Entities entitiy, int value);

        public static abstract IEnumerable<T> ReadAll<T>(string path, 
            DB_Entities rootName = DB_Entities.None) 
            where T : IAuditable<T>;

        public static abstract void AppendObjectToBase<T>(string path, T obj, 
            DB_Entities rootName = DB_Entities.None) 
            where T : IAuditable<T>;

        public static abstract bool RemoveFromDB<T>(string path, int id, 
            DB_Entities rootName = DB_Entities.None) 
            where T : IAuditable<T>;

        public static abstract bool UpdateObject<T>(string path, T obj, int id,
            DB_Entities rootName = DB_Entities.None) 
            where T : IAuditable<T>;

        public static abstract T GetById<T>(string path, int id,
            DB_Entities rootName = DB_Entities.None)
            where T : IAuditable<T>;
    }
}
