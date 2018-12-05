using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tel { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Name, Title);
        }
    }
}
