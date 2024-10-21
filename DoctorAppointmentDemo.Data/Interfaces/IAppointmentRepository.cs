using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        //appointment repos future methods

        public bool BloodSampleBrief { get; set; }
        public bool BloodSampleFull {  get; set; }

        public bool XRayProcedure { get; set; }
    }
}
