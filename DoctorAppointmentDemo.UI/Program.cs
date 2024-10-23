using DoctorAppointmentDemo.Data.DB_Services;
using DoctorAppointmentDemo.UI;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.DB_Services;
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
            _doctorService = new DoctorService(DataStoragePath, new JSON_DB_Service());
            _patientService = new PatientService(DataStoragePath, new JSON_DB_Service());
            _appointmentService = new AppointmentService(DataStoragePath, new JSON_DB_Service());

        }

        public DoctorAppointment(string db_settingsPath, IManageDB_Sources source)
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


            SourceDB sourceChoise = (SourceDB)choise;

            IManageDB_Sources source = null;

            switch (sourceChoise)
            {
                case SourceDB.JSON: dataSource = MyConstants.JSON_DB_SETTINGS_PATH; source = new JSON_DB_Service(); break;
                case SourceDB.XML: dataSource = MyConstants.XML_DB_SETTINGS_PATH; source = new XML_DB_Service(); break;
            }


            if(source is not null)
            {
                var doctorAppointment = new DoctorAppointment(dataSource, source);
                //doctorAppointment.Run();

                TestBlock test = new TestBlock(doctorAppointment);
                test.RunTestBlock();
            }
            else
            {
                Console.WriteLine("Source must be chosen correctly! Try again");
                Console.ReadLine();
            }
            
        }
    }
}