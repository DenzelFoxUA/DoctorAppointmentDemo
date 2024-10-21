using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IManageClinicEntities<Patient>
    {
        private readonly IPatientRepository _patientReository;

        public PatientService(string db_settingsFilePath, SourceDB source)
        {
            _patientReository = new PatientRepository(db_settingsFilePath, source);
        }

        public Patient Create(Patient patient)
        {
            return _patientReository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientReository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientReository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientReository.GetAll();
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientReository.Update(id, patient);
        }
    }
}
