using MyDoctorAppointment.Domain.Interfaces;

namespace MyDoctorAppointment.Domain.Entities
{
    public abstract class UserBase : IAuditable<UserBase>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public byte Age { get; set; } = 0;

        public string? Phone { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id}: {Name}, {Surname}\n" +
                $"Age: {Age}\n" +
                $"Contacts: " +
                $"Cellphone {Phone}\n" +
                $"email {Email}";
        }

    }
}
