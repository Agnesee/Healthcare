using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Vardcentral.DAL
{
    public class VardcentralDatabas : DbContext
    {

        public VardcentralDatabas() : base("Data Source=LAPTOP-DHV5KD3D;Initial Catalog=Healthcare;Integrated Security=True")
        { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}