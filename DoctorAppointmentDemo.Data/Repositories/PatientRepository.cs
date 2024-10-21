using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Configuration;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository(string db_settingsFilePath, SourceDB source)
        {
            var result = DB_AppSettings(db_settingsFilePath);
            SourceDB = source;
            EntityName = DB_Entities.Patients;
            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient) => Console.WriteLine(patient);

        
    }
}
