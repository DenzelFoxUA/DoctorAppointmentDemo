namespace MyDoctorAppointment.Data.Configuration
{
    public static class MyConstants
    {
        
        public const string JSON_DB_SETTINGS_FILE_NAME = "JSON_DB_settings.json";
        public const string XML_DB_SETTINGS_FILE_NAME = "XML_DB_settings.json";

        public const string JSON_DB_SETTINGS_PATH = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\JSON_DB_settings.json";
        public const string XML_DB_SETTINGS_PATH = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\XML_DB_settings.json";

        //public static string JSON_DB_SettingsFilePath = Path.Combine(Environment.CurrentDirectory, MyConstants.JSON_DB_SETTINGS_FILE_NAME);
        //public static string XML_DB_SettingsFilePath = Path.Combine(Environment.CurrentDirectory, MyConstants.XML_DB_SETTINGS_FILE_NAME);

        public const string DB_NAME = "Database";
    }

    public enum DB_Entities
    {
        None = 0,
        Doctors,
        Patients,
        Appointments
    }

    public enum SourceDB
    { 
        None = 0,
        JSON,
        XML,
        SQL
    }

}
