using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? Address { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                $"\nDiagnosis: {IllnessType}\n" +
                $"Sympthoms: \n" +
                $"{AdditionalInfo}\n" +
                $"Address: {Address}";
        }

        private Patient()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Age = 1;
            Phone = string.Empty;
            Email = string.Empty;
            IllnessType = IllnessTypes.Ambulance;
            AdditionalInfo = string.Empty;
            Address = string.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        private Patient(string name,
                       string surname,
                       byte age,
                       string cellphone,
                       string email,
                       IllnessTypes illness,
                       string info,
                       string address)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Phone = cellphone;
            Email = email;
            IllnessType = illness;
            AdditionalInfo = info;
            Address = address;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public class PatientBuilder : IDisposable
        {
            private string _name = string.Empty;
            private string _surname = string.Empty;
            private byte _age;
            private string _phone = string.Empty;
            private string _email = string.Empty;
            private IllnessTypes _illness;
            private string _info;
            private string _address;


            public PatientBuilder Name(string? name)
            {
                if (name is not null || name != string.Empty)
                {
                    _name = name;
                }
                return this;
            }
            public PatientBuilder Surame(string? surname)
            {
                if (surname is not null || surname != string.Empty)
                {
                    _surname = surname;
                }

                return this;
            }
            public PatientBuilder Age(byte age)
            {
                if (age > 0)
                    _age = age;

                return this;
            }
            public PatientBuilder Cellphone(string? number)
            {
                if (number is not null || number != string.Empty)
                {
                    _phone = number;
                }
                return this;
            }
            public PatientBuilder EMail(string? mail)
            {
                if (mail is not null || mail != string.Empty)
                {
                    _email = mail;
                }
                return this;
            }
            public PatientBuilder Illness(IllnessTypes illness)
            {
                _illness = illness;
                return this;

            }

            public PatientBuilder Info(string ?info)
            {
                if (info is not null || info != string.Empty)
                    _info = info;

                return this;
            }

            public PatientBuilder Address(string ?address)
            {
                if (address is not null || address != string.Empty)
                {
                    _address = address;
                }
                return this;
            }

            public Patient Build()
            {
                return new Patient(_name, _surname, _age, _phone, _email, _illness, _info, _address);
            }

            public void Dispose()
            {
                _name = string.Empty;
                _surname = string.Empty;
                _age = 0;
                _phone = string.Empty;
                _email = string.Empty;
                _illness = IllnessTypes.Ambulance;
                _info = string.Empty;
                _address = string.Empty;
            }
        }
    }
}
