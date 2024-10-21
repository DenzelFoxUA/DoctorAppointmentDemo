using MyDoctorAppointment.Domain.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository: IGenericRepository<Doctor>
    {
        // you can add more specific doctor's methods

       public List<Doctor> GetBySpeciality(DoctorSpeciality speciality);
    }
}
