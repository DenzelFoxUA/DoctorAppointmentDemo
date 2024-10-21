using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment;
using MyDoctorAppointment.Domain.Interfaces;
using MyDoctorAppointment.Service.Interfaces;
using static MyDoctorAppointment.Domain.Entities.Doctor;

namespace DoctorAppointmentDemo.UI
{
    //цей клас створений виключно для тестування можливостей і функцій. Після тесту його буде видалено.
    //може кидатись exctption'ами, бо тут не реалізована логіка іх перехвату
    //наприклад коли об єкт вже було видалено, механізм пошуку повертає нульове значення
    //
    public class TestBlock
    {
        private DoctorAppointment _doctorAppointmentTestObject;

        public TestBlock()
        {
            _doctorAppointmentTestObject = new DoctorAppointment();
        }

        public TestBlock(DoctorAppointment doctorAppointmentTestObject)
        {
            _doctorAppointmentTestObject = doctorAppointmentTestObject;
        }

        public void RunTestBlock()
        {
            //1 створити та показати сутності лікарні
            CreateSomeObjectsAndPrintToConsole();
            Console.Clear();

            //2 вибірка сутностей по айді
            GetByIdAndPrintToTheConsole();
            Console.Clear();

            //3 видалення
            DeleteObject();
            Console.Clear();
            //4 апдейт сутностей
            Update();
            Console.Clear();
        }

        private void CreateSomeObjectsAndPrintToConsole()
        {
            using (Doctor.DoctorBuilder doctorBuilder = new Doctor.DoctorBuilder())
            {
                var doc1 = doctorBuilder.Name("Semen")
                                        .Surame("Klemenko")
                                        .Age(50)
                                        .Speciality(DoctorSpeciality.Dermatologist)
                                        .Cellphone("0500001122")
                                        .EMail("SKlemenkoDoc@gmail.com")
                                        .Expirience(20)
                                        .Salary(100000M)
                                        .Build();



                _doctorAppointmentTestObject.DoctorService.Create(doc1);


            }

            using (Doctor.DoctorBuilder doctorBuilder = new Doctor.DoctorBuilder())
            {
                var doc2 = doctorBuilder.Name("Samantha")
                                        .Surame("Fox")
                                        .Age(30)
                                        .Speciality(DoctorSpeciality.Paramedic)
                                        .Cellphone("0507771122")
                                        .EMail("SAMFOX@gmail.com")
                                        .Expirience(10)
                                        .Salary(50000M)
                                        .Build();
                DoctorAppointmentOperations.AddObjectRecord(doc2, _doctorAppointmentTestObject.DoctorService);
            }



            using (Patient.PatientBuilder patientBuilder = new Patient.PatientBuilder())
            {
                var patient1 = patientBuilder.Name("Max")
                                             .Surame("Payne")
                                             .Age(40)
                                             .Cellphone("0661116661")
                                             .EMail("maxpayne@gmail.com")
                                             .Info("Headache")
                                             .Illness(IllnessTypes.Infection)
                                             .Address("New York city, 13th street")
                                             .Build();

                DoctorAppointmentOperations.AddObjectRecord(patient1, _doctorAppointmentTestObject.PatientService);
            }

            using (Patient.PatientBuilder patientBuilder = new Patient.PatientBuilder())
            {
                var patient2 = patientBuilder.Name("Brian")
                                             .Surame("Dawson")
                                             .Age(40)
                                             .Cellphone("0664557712")
                                             .EMail("dawson@gmail.com")
                                             .Info("Eye woonded")
                                             .Illness(IllnessTypes.EyeDisease)
                                             .Address("New York city, 15th street")
                                             .Build();

                DoctorAppointmentOperations.AddObjectRecord(patient2, _doctorAppointmentTestObject.PatientService);

            }

            //ці значення можуть бути null тому що об'єкт було видалено на минулому тесті і айді відсутній
            var doctor1 = _doctorAppointmentTestObject.DoctorService.Get(1);
            var pat1 = _doctorAppointmentTestObject.PatientService.Get(1);

            var doctor2 = _doctorAppointmentTestObject.DoctorService.Get(2);
            var pat2 = _doctorAppointmentTestObject.PatientService.Get(2);

            if(doctor1 is not null && pat1 is not null)
            DoctorAppointmentOperations.CreateAppointmentRecord(doctor1.Id,
                                                                pat1.Id,
                                                                DateTime.UtcNow,
                                                                DateTime.UtcNow.AddHours(1),
                                                                "Appointment 1",
                                                                (AppointmentService)_doctorAppointmentTestObject.AppointmentService);

            if (doctor2 is not null && pat2 is not null)
            DoctorAppointmentOperations.CreateAppointmentRecord(doctor2.Id,
                                                                pat2.Id,
                                                                DateTime.UtcNow,
                                                                DateTime.UtcNow.AddHours(2),
                                                                "Appointment 2",
                                                                (AppointmentService)_doctorAppointmentTestObject.AppointmentService);


            DoctorAppointmentOperations.ShowAppointments(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllPatients(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllDoctors(_doctorAppointmentTestObject);
        }

        private void GetByIdAndPrintToTheConsole()
        {
            Console.WriteLine(DoctorAppointmentOperations.GetObjectById(_doctorAppointmentTestObject.DoctorService, 1));
            Console.WriteLine(DoctorAppointmentOperations.GetObjectById(_doctorAppointmentTestObject.PatientService, 1));
            Console.WriteLine(DoctorAppointmentOperations.GetObjectById(_doctorAppointmentTestObject.AppointmentService, 1));
        }

        private void DeleteObject()
        {
            _doctorAppointmentTestObject.DoctorService.Delete(2);
            _doctorAppointmentTestObject.PatientService.Delete(2);
            _doctorAppointmentTestObject.AppointmentService.Delete(2);

            DoctorAppointmentOperations.ShowAppointments(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllPatients(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllDoctors(_doctorAppointmentTestObject);
        }

        private void Update()
        {
            using (var doctorBuilder = new DoctorBuilder())
            {
                var doc = doctorBuilder.Name("Test")
                                            .Surame("Test")
                                            .Age(30)
                                            .Speciality(DoctorSpeciality.Dermatologist)
                                            .Cellphone("0000000000")
                                            .EMail("TEST.EMAIL")
                                            .Expirience(10)
                                            .Salary(1M)
                                            .Build();



                _doctorAppointmentTestObject.DoctorService.Update(1, doc);
            }

            using (Patient.PatientBuilder patientBuilder = new Patient.PatientBuilder())
            {
                var patient = patientBuilder.Name("Test")
                                             .Surame("Test")
                                             .Age(40)
                                             .Cellphone("000000000")
                                             .EMail("TEST.com")
                                             .Info("SOMETEST")
                                             .Illness(IllnessTypes.EyeDisease)
                                             .Address("DEFAULT")
                                             .Build();

                _doctorAppointmentTestObject.PatientService.Update(1, patient);

            }

            DoctorAppointmentOperations.ShowAppointments(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllPatients(_doctorAppointmentTestObject);

            DoctorAppointmentOperations.ShowAllDoctors(_doctorAppointmentTestObject);
        }
    }

    //shortcut test methods
    public static class DoctorAppointmentOperations
    {
        //дженерік метод для тестування додавання сутностей в бд
        //всі сутності реалізують загальний для них інтерфейс, тому легко можна підставити будь-який обєкт з них
        public static void AddObjectRecord<T>(T doctor, IManageClinicEntities<T> service) where T : IAuditable<T>
        {
            service.Create(doctor);
        }

        //цей метод створений окремо, бо тут обєкт appointment створюється з параметрів, але якщо передавати готовий обєкт
        //то можна використати попередній метод
        public static void CreateAppointmentRecord(int doctorId,
                                             int patientId,
                                             DateTime when,
                                             DateTime dateTimeTo,
                                             string shortDescribtion,
                                             AppointmentService service)
        {
            var appointment = new Appointment
            {
                PatientId = patientId,
                DoctorId = doctorId,
                DateTimeFrom = when,
                DateTimeTo = dateTimeTo,
                Description = shortDescribtion

            };

            service.Create(appointment);
        }

        public static void ShowAllDoctors(DoctorAppointment repositories)
        {
            var collection = repositories.DoctorService.GetAll().ToList();

            MyPrinter.MyPrinter.Print(collection, "Doctors:\n");
        }

        public static void ShowAllPatients(DoctorAppointment repositories)
        {
            var collection = repositories.PatientService.GetAll().ToList();
            MyPrinter.MyPrinter.Print(collection, "Patients:\n");

        }

        public static void ShowAppointments(DoctorAppointment repositories)
        {

            var collection = repositories.AppointmentService.GetAll().ToList();
            MyPrinter.MyPrinter.Print(collection, "Appoinments:\n");

        }

        //так само і цей метод може приймати будь-який обєкт що реалізує інтерфейс IAuditable<T>
        public static T GetObjectById<T>(IManageClinicEntities<T> service, int id) where T : IAuditable<T>
        {
            return service.Get(id)!;
        }

    }

}

