using MyDoctorAppointment.Domain.Interfaces;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment : IAuditable<Appointment>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public Patient? Patient { get; set; }

        //public Doctor? Doctor { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }

        public Appointment()
        {
            Id = 0;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = DateTime.MinValue;
            PatientId = -1;
            DoctorId = -1;
            DateTimeFrom = DateTime.MinValue;
            DateTimeTo = DateTime.MinValue;
            Description = string.Empty;
        }

        public Appointment(int id, int patient, int doctor, DateTime when, DateTime dateTimeTo)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt= DateTime.UtcNow;
            PatientId = patient;
            DoctorId = doctor;
            DateTimeFrom = when;
            DateTimeTo = dateTimeTo;
        }

        public override string ToString()
        {
            return $"Appointment: {Id}\n" +
                $"Doctor: {DoctorId}\n" +
                $"DateTime of Appointment: {DateTimeFrom}\n" +
                $"Patient: {PatientId}\n" + 
                $"Till: {DateTimeTo.Hour}:{DateTimeTo.Minute}\n" +
                $"Created* {CreatedAt}, Updated*{UpdatedAt}";
        }
    }
}
