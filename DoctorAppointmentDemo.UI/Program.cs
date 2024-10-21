using DoctorAppointmentDemo.UI;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IManageClinicEntities<Doctor> _doctorService;
        private readonly IManageClinicEntities<Patient> _patientService;
        private readonly IManageClinicEntities<Appointment> _appointmentService;

        public string DataStoragePath { get; init; }


        public IManageClinicEntities<Doctor> DoctorService => _doctorService;
        public IManageClinicEntities<Patient> PatientService => _patientService;
        public IManageClinicEntities<Appointment> AppointmentService => _appointmentService;

        public DoctorAppointment()
        {
            DataStoragePath = MyConstants.JSON_DB_SETTINGS_PATH; //default storage
            _doctorService = new DoctorService(DataStoragePath, SourceDB.JSON);
            _patientService = new PatientService(DataStoragePath, SourceDB.JSON);
            _appointmentService = new AppointmentService(DataStoragePath, SourceDB.JSON);

        }

        public DoctorAppointment(string db_settingsPath, SourceDB source)
        {
            DataStoragePath = db_settingsPath;
            _doctorService = new DoctorService(DataStoragePath, source);
            _patientService = new PatientService(DataStoragePath, source);
            _appointmentService = new AppointmentService(DataStoragePath, source);

        }

        public void Run()
        {
            //future app logic
        }
    }

    public static class Program
    {
        public static void Main()
        {
            string dataSource = string.Empty;


            Console.WriteLine($"Select DB source:\n" +
                $"1 - JSON\n" +
                $"2 - XML\n");

            int choise = 0;
            string? input = Console.ReadLine();
            int.TryParse(input, out choise);


            SourceDB source = (SourceDB)choise;


            switch (source)
            {
                case SourceDB.JSON: dataSource = MyConstants.JSON_DB_SETTINGS_PATH; break;
                case SourceDB.XML: dataSource = MyConstants.XML_DB_SETTINGS_PATH; break;
            }



            var doctorAppointment = new DoctorAppointment(dataSource, source);
            //doctorAppointment.Run();

            TestBlock test = new TestBlock(doctorAppointment);
            test.RunTestBlock();
        }
    }
}