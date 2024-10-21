namespace MyDoctorAppointment.Domain.Interfaces
{
    public interface IAuditable<in T>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
