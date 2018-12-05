using System;
using System.Collections.Generic;
using Vardcentral.DAL;

namespace WpfApp1.Model
{
    public class Controller
    {
        private List<Appointment> Appointment = new List<Appointment>();
        private VardcentralDAL dal = new VardcentralDAL();



        public string AddOrUpdateEmployee(Employee employee)
        {
            //if (employee == null)
            //{
            //    return "lägg till nått felmeddelande";
            //}
            //var existingEmployee = dal.GetEmployeeById(employee.EmployeeID);
            //if (existingEmployee != null)
            //{

            //    if (dal.UpdateEmployee(employee))
            //    {
            //        return $"Employee {employee.Name} has been updated successfully";
            //    }
            //    else
            //        return $"Failed to update employee {employee.Name}.";
            //}
            //else
            //{
            //    if (dal.AddEmployee(employee))
            //    {
            //        return $"Employee {employee.Name} has been added successfully";
            //    }
            //    else
            //        return $"Failed to add employee {employee.Name}.";
            //}
            string s = dal.AddOrUpdateEmployee(employee);
            return s;

        }

        public string DeleteEmployee(string ssn)
        {
            //if (this.dal.DeleteEmployee(ssn))
            //{
            //    return "Employee has been deleted.";
            //}
            //else
            //    return "Employee does not exist or couldn't be deleted";
            string s = dal.DeleteEmployee1(ssn);
            return s;
        }

        public List<Employee> GetAllEmployees()
        {
            return this.dal.GetAllEmployees();
        }

        public string AddOrUpdatePatient(Patient patient)
        {
            //    if (patient == null)
            //    {
            //        return "Something went wrong, please try again";
            //    }
            //    var existingPatient = dal.GetPatientById(patient.PatientID);
            //    if (existingPatient != null)
            //    {
            //        if (dal.UpdatePatient(patient))
            //        {
            //            return $"Patient {patient.Name} has been updated successfully";
            //        }
            //        else
            //            return $"Failed to update patient {patient.Name}.";
            //    }
            //    else
            //    {
            //        if (dal.AddPatient(patient))
            //        {
            //            return $"Patient {patient.Name} has been added successfully";
            //    }
            //        else
            //            return $"Failed to add patient {patient.Name}.";
            //}
            string s = dal.AddOrUpdatePatient(patient);
            return s;
        }

        public string DeletePatient(string ssn)
        {
            //if (this.dal.DeletePatient(ssn))
            //{
            //    this.dal.DeletePatient(ssn);
            //    return "Patient has been deleted.";
            //}
            //else

            //    return "";
            //    //return "Patient does not exist or couldn't be deleted";
            string s = dal.DeletePatient1(ssn);
            return s;
        }

        public void AddPatient(Patient patient)

        {
            this.dal.AddPatient(patient);
        }

        public Patient GetPatient(string ssn)
        {
            return this.dal.GetPatientById(ssn);
        }

        public List<Patient> GetAllPatients()
        {
            return this.dal.GetAllPatients();
        }

        //metod för att kunna hitta employee via drop-down

        //döp om shit till appointment
        public string AddAppointment(Employee employee, Patient patient, DateTime dateFrom, DateTime dateTo)
        {
            var appointment = new Appointment
            {
                Employee = employee,
                Patient = patient,
                DateFrom = dateFrom,
                DateTo = dateTo,
                EmployeeID = employee.EmployeeID,
                PatientID = patient.PatientID
            };
            //if(!dal.CheckIfAppointmentAvailable(appointment))
            //{
            //    return "Appointment time is taken, please choose another time.";
            //}
            //if(this.dal.AddAppointment(appointment))
            //{
            //    return "Appointment has been added.";
            //}
            //else
            //{
            //    return "Appointment couldn't be saved.";
            //}
            string s = dal.AddAppointment(employee, patient, dateFrom, dateTo);
            return s;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            return this.dal.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAppointmentsByPatientId(string patientSSN)
        {
            return dal.GetAppointmentsByPatientId(patientSSN);
        }

        public List<Appointment> GetAppointmentsByEmployeeId(string employeeId)
        {
            return dal.GetAppointmentsByEmployeeId(employeeId);
        }
    }
}
