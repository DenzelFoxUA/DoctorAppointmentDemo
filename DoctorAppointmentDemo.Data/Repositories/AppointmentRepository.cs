using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.DB_Services;
using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.DB_Services;
using Newtonsoft.Json;
using MyDoctorAppointment.Data.Configuration;

namespace MyDoctorAppointment.Data.Repositories
{
    //наслідується від базового класу репозиторія і має всі його методи
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        //unnescesarry extentions
        public bool BloodSampleBrief { get; set; }
        public bool BloodSampleFull { get; set; }
        public bool XRayProcedure { get; set; }
        //

        public AppointmentRepository(string db_settingsPath, SourceDB source)
        {
            var result = DB_AppSettings(db_settingsPath);
            SourceDB = source;
            EntityName = DB_Entities.Appointments;
            Path = result.Database.Appointments.Path;
            LastId = result.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment source) => Console.WriteLine(source);

        
    }
}
