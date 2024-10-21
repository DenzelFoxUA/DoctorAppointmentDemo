

namespace DoctorAppointmentDemo.Data.DB_Services
{
    public static class DB_DataStructure
    {   
        //набір классів для реалізації моделі даних налаштувань (JSON & XML settings files)
        public class AppointmentsData : EntityData
        {
            public override int LastId { get; set; }
            public override string Path { get; init; } = string.Empty;
        }

        public class MainDB
        {
            public DoctorsData? Doctors { get; set; }
            public PatientsData? Patients { get; set; }
            public AppointmentsData? Appointments { get; set; }
        }

        public class DoctorsData : EntityData
        {
            public override int LastId { get; set; }
            public override string Path { get; init; } = string.Empty;
        }

        public class PatientsData : EntityData
        {
            public override int LastId { get; set; }
            public override string Path { get; init; } = string.Empty;
        }

        public abstract class EntityData
        {
            public abstract int LastId { get; set; }
            public abstract string Path { get; init; }

            public override string ToString()
            {
                return LastId.ToString();
            }

        }
        public class DB_Root
        {
            public MainDB? Database { get; set; }

        }
    }
}
