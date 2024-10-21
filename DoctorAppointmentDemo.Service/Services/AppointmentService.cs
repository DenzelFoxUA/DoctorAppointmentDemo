using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IManageClinicEntities<Appointment>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public string DB_SettingsPath { get; init; }

        public AppointmentService(string db_settingsFilePath, SourceDB source)
        {
            DB_SettingsPath = db_settingsFilePath;
            _appointmentRepository = new AppointmentRepository(DB_SettingsPath, source);
        }


        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
