using MyDoctorAppointment.Domain.Interfaces;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IManageClinicEntities<T> where T : IAuditable<T>
    {
        T Create(T entity);

        IEnumerable<T> GetAll();

        T? Get(int id);

        bool Delete(int id);

        T Update(int id, T entity);
    }
}
