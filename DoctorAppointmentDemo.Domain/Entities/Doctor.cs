using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorSpeciality DoctorSpeciality { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }

        private Doctor()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Age = 1;
            Phone = string.Empty;
            Email = string.Empty;
            DoctorSpeciality = DoctorSpeciality.Dentist;
            Experience = 0;
            Salary = 0M;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        private Doctor(string name,
                       string surname,
                       byte age,
                       string cellphone,
                       string email,
                       DoctorSpeciality speciality,
                       byte experience,
                       decimal salary)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Phone = cellphone;
            Email = email;
            DoctorSpeciality = speciality;
            Experience = experience;
            Salary = salary;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public class DoctorBuilder : IDisposable
        {
            private string _name = string.Empty;
            private string _surname = string.Empty;
            private byte _age;
            private string _phone = string.Empty;
            private string _email = string.Empty;
            private DoctorSpeciality _speciality;
            private byte _experience;
            private decimal _salary;
            

            public DoctorBuilder Name(string ?name)
            {
                if (name is not null || name != string.Empty)
                {
                    _name = name;
                }
                return this;
            }
            public DoctorBuilder Surame(string? surname)
            {
                if(surname is not null || surname != string.Empty)
                {
                    _surname = surname;
                }
               
                return this;
            }
            public DoctorBuilder Age(byte age)
            {
                if(age > 0)
                    _age = age;

                return this;
            }
            public DoctorBuilder Cellphone(string ?number)
            {
                if (number is not null || number != string.Empty)
                {
                    _phone = number;
                }
                    return this;
            }
            public DoctorBuilder EMail(string ?mail)
            {
                if (mail is not null || mail != string.Empty)
                {
                    _email = mail;
                }
                return this;
            }
            public DoctorBuilder Speciality(DoctorSpeciality speciality)
            {
                _speciality = speciality;
                return this;

            }

            public DoctorBuilder Expirience(byte years)
            {
                if(years > 0)
                    _experience = years;

                return this;
            }

            public DoctorBuilder Salary(decimal value)
            {
                if (value >= 0)
                {
                    _salary = value;
                }
                return this;
            }

            public Doctor Build()
            {
                return new Doctor(_name, _surname, _age, _phone, _email, _speciality, _experience, _salary);
            }

            public void Dispose()
            {
                _name = string.Empty;
                _surname = string.Empty;
                _age = 0;
                _phone = string.Empty;
                _email = string.Empty;
                _speciality = DoctorSpeciality.FamilyDoctor;
                _experience = 0;
                _salary = 0M;
            }
        }


        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Speciality: {DoctorSpeciality}\n" +
                $"Experience: {Experience}\n" +
                $"Salary:{Salary}";
        }
    }
}
