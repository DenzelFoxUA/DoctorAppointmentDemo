using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Interfaces;

namespace DoctorAppointmentDemo.Data.DB_Services
{

    //інтерфейс, який повинні реалізувати всі сервіси, що керують потоком даних в БД
    public interface IManageDB_Sources
    {
        public void ModifyId(DB_Entities entitiy, int value);

        public IEnumerable<T> ReadAll<T>(string path, 
            DB_Entities rootName) 
            where T : IAuditable<T>;

        public void AppendObjectToBase<T>(string path, T obj, 
            DB_Entities rootName) 
            where T : IAuditable<T>;

        public bool RemoveFromDB<T>(string path, int id, 
            DB_Entities rootName) 
            where T : IAuditable<T>;

        public bool UpdateObject<T>(string path, T obj, int id,
            DB_Entities rootName) 
            where T : IAuditable<T>;

        public T GetById<T>(string path, int id,
            DB_Entities rootName)
            where T : IAuditable<T>;
    }
}
