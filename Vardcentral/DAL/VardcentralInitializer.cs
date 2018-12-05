using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Vardcentral.DAL
{
    public class VardcentralInitializer : DropCreateDatabaseIfModelChanges<VardcentralDatabas>
    {
        //FUNKAR INTE!!!!!!!!!!!!!!!!! Fick ej att köra on startup då model ändrats.
        //protected override void Seed(VardcentralDatabas context)
        //{
        //    var Employees = new List<Employee>
        //    {
        //    new Employee{EmployeeID="0001",Name="Agnes",Address="Adelgatan",Tel="072354", Title="Developer"}
        //    };
        //    Employees.ForEach(s => context.Employees.Add(s));
        //    context.SaveChanges();

        //    var Patients = new List<Patient>
        //    {
        //    new Patient{PatientID="1050",Name="Kalle", Address="Bankgatan", Tel="3697234", Note="sdfsdfsadf asdf"},
        //    new Patient{PatientID="4022",Name="sdf", Address="Jallagatan", Tel="3697234222", Note="sdfsdfsadf asdf"}
        //    };
        //    Patients.ForEach(s => context.Patients.Add(s));
        //    context.SaveChanges();
        //    var Appointments = new List<Appointment>
        //    {
        //    new Appointment{EmployeeID="0001",PatientID="1050",DateFrom=DateTime.Parse("2018-02-28 10:00:00"), DateTo=DateTime.Parse("2018-02-28 12:00:00")},
        //    new Appointment{EmployeeID="0001",PatientID="1045",DateFrom=DateTime.Parse("2018-03-01 10:00:00"), DateTo=DateTime.Parse("2018-03-01 12:00:00")}
        //    };
        //    Appointments.ForEach(s => context.Appointments.Add(s));
        //    context.SaveChanges();
        //}
    }
}
