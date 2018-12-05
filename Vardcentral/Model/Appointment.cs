using System;

namespace WpfApp1.Model
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; } 
    }
}
