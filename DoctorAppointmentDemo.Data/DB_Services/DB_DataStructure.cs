

namespace DoctorAppointmentDemo.Data.DB_Services
{
    public static class DB_DataStructure
    {   
        //набір классів для реалізації моделі даних налаштувань (JSON & XML settings files)

        public class MainDB
        {
            public EntityData? Doctors { get; set; }
            public EntityData? Patients { get; set; }
            public EntityData? Appointments { get; set; }
        }

        public class EntityData
        {
            public int LastId { get; set; }
            public string Path { get; init; }

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
