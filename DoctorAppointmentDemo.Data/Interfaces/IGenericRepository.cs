using MyDoctorAppointment.Domain.Interfaces;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : IAuditable<TSource>
    {

        TSource Create(TSource source);

        TSource? GetById(int id);

        TSource Update(int id, TSource source);

        IEnumerable<TSource> GetAll();

        bool Delete(int id);
    }
}
