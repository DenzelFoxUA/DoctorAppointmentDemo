using DoctorAppointmentDemo.Data.DB_Services;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Interfaces;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : IAuditable<TSource>
    {

        public DB_Entities EntityName { get; init; }

        public IManageDB_Sources IDBService { get; init; }

        TSource Create(TSource source);

        TSource? GetById(int id);

        TSource Update(int id, TSource source);

        IEnumerable<TSource> GetAll();

        bool Delete(int id);
    }
}
