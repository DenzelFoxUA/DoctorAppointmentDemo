using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository(string db_settingsFilePath, SourceDB source)
        {
            var result = DB_AppSettings(db_settingsFilePath);
            SourceDB = source;
            EntityName = DB_Entities.Doctors;
            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public List<Doctor> GetBySpeciality(DoctorSpeciality speciality)
        {
            return GetAll().Where(x => x.DoctorSpeciality == speciality).ToList();
        }

        public override void ShowInfo(Doctor doctor) => Console.WriteLine(doctor);
        
    }
}
