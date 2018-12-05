using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Patient
    {
        public string PatientID { get; set; }
        public string Name { get; set; }
        public int Tel { get; set; }
        public string Address { get; set;}
        public string Note { get; set; }

        public ICollection<Appointment> Appointments{ get; set; }

        public override string ToString()
        {
            return $"{PatientID}, {Name}";
        }
    }

}
