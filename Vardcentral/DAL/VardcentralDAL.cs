using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Vardcentral.Exceptions;

namespace Vardcentral.DAL
{
    class VardcentralDAL
    {
        private VardcentralDatabas db = new VardcentralDatabas();
        private readonly string connectionString = "Server=(local);DataBase=HealthCare;Integrated Security=SSPI";
        private object context;

        public bool AddEmployee(Employee employee)
        {
            this.db.Employees.Add(employee);
            int result = this.db.SaveChanges();
            return result > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            int result = 0;
            var existingEmployee = db.Employees.FirstOrDefault(e => e.EmployeeID.Equals(employee.EmployeeID));
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Tel = employee.Tel;
                existingEmployee.Title = employee.Title;
                existingEmployee.Address = employee.Address;
                result = db.SaveChanges();
            }
            return result > 0;
        }

        public bool DeleteEmployee(string ssn)
        {
            var result = 0;
            var employeeToDelete = db.Employees.FirstOrDefault(e => e.EmployeeID.Equals(ssn));
            if (employeeToDelete != null)
            {
                db.Employees.Remove(employeeToDelete);
                result = db.SaveChanges();
            }
            return result > 0;
        }
        public List<Employee> GetAllEmployees()
        {
            //maybe here
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(string ssn)
        {
            return db.Employees.FirstOrDefault(e => e.EmployeeID.Equals(ssn));
        }

        public List<Patient> GetAllPatients()
        {

            //maybe here

            return this.db.Patients.ToList();
        }

        public bool AddPatient(Patient patient)
        {


            this.db.Patients.Add(patient);
            int results = this.db.SaveChanges();
            return results > 0;
        }

        public bool UpdatePatient(Patient patient)
        {
            int result = 0;
            var existingPatient = db.Patients.FirstOrDefault(e => e.PatientID.Equals(patient.PatientID));

            if (existingPatient != null)
            {
                existingPatient.Name = patient.Name;
                existingPatient.Tel = patient.Tel;
                existingPatient.Note = patient.Note;
                existingPatient.Address = patient.Address;
                result = db.SaveChanges();
            }

            return result > 0;
        }

        public bool DeletePatient(string ssn)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePatient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatientID", SqlDbType.VarChar).Value = ssn;
                    //        new SqlParameter("Tel", patient.Tel),
                    //        new SqlParameter("Address", patient.Address),
                    //        new SqlParameter("Note", patient.Note));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            int results = this.db.SaveChanges();
            return results > 0;


            //    int result;

            //using (SqlConnection connection = new SqlConnection())
            //{

            //    String query = "exec DeletePatient" + "'" + ssn + "'";

            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        //command.Parameters.AddWithValue("@id", "abc");

            //        connection.Open();
            //        result = command.ExecuteNonQuery();

            //        // Check Error
            //        if (result < 0)
            //            Console.WriteLine("Error inserting data into Database!");
            //    }
            //}
            //return result > 0;

            //using (var context = new VardcentralDatabas())
            //{
            //    //var result = 
            //        context.Database.SqlQuery<Patient>(
            //        "DeletePatient @PatientID",
            //        new SqlParameter("PatientID", ssn));
            //}


            //var result = 0;
            //var patientToDelete = db.Patients.FirstOrDefault(e => e.PatientID.Equals(ssn));
            //if (patientToDelete != null)
            //{
            //    db.Patients.Remove(patientToDelete);
            //    result = db.SaveChanges();
            //}
            //return result > 0;
        }

        public Patient GetPatientById(string ssn)
        {
            return db.Patients.FirstOrDefault(e => e.PatientID.Equals(ssn));
        }

        public bool AddAppointment(Appointment appointment)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.Add(new SqlParameter("@AppointmentID", appointment.AppointmentID));
                    cmd.Parameters.Add(new SqlParameter("@PatientID", appointment.PatientID));
                    cmd.Parameters.Add(new SqlParameter("@DateFrom", appointment.DateFrom));
                    cmd.Parameters.Add(new SqlParameter("@DateTo", appointment.DateTo));
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", appointment.EmployeeID));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //"@PatientID", SqlDbType.VarChar).Value = appointment.PatientID;

            //if(appointment != null)
            //{
            //    this.db.Appointments.Add(appointment);
            //    result = this.db.SaveChanges();
            //}
            return result > 0;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            var result = 0;
            var appointmentToDelete = db.Appointments.FirstOrDefault(a => a.AppointmentID.Equals(appointment.AppointmentID));
            if (appointmentToDelete != null)
            {
                this.db.Appointments.Remove(appointmentToDelete);
                result = this.db.SaveChanges();
            }
            return result > 0;
        }

        //public bool CheckIfAppointmentAvailable(Appointment appointment)
        //{
        //    var existingAppointment = db.Appointments.Where(x => (x.DateTo >= appointment.DateFrom && x.DateFrom <= appointment.DateTo)
        //                                //&& (x.PatientID.Equals(appointment.PatientID) || x.EmployeeID.Equals(appointment.EmployeeID))
        //                                );
        //    return !existingAppointment.Any();
        //}

        public List<Appointment> GetAppointmentsByPatientId(string patientSSN)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    var appointments = con.Query<Appointment>("GetAppointmentsByPatientId", new { PatientId = patientSSN }, commandType: CommandType.StoredProcedure).ToList();
                    return appointments;
                }
            }
            catch (SqlException)
            {
                throw new CustomException("Exception when trying to get appointments by patientId from database");
            }
        }

        public List<Appointment> GetAppointmentsByEmployeeId(string employeeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    var appointments = con.Query<Appointment>("GetAppointmentsByEmployeeId", new { EmployeeId = employeeId }, commandType: CommandType.StoredProcedure).ToList();
                    return appointments;
                }
            }
            catch (SqlException)
            {
                throw new CustomException("Exception when trying to get appointments by employeeId from database");
            }
        }
        // Additional code starting from here 
        StringBuilder errorMessages = new StringBuilder();

        public string AddOrUpdateEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException("Invaild Input of Employee. Input cannot be empty.");
            }

            var existingEmployee = GetEmployeeById(employee.EmployeeID);
            try
            {
                if (existingEmployee != null)
                {
                    if (UpdateEmployee(employee))
                    {
                        return $"Employee {employee.Name} has been updated successfully";
                    }
                    else return "Update failed.";
                }
                else
                {
                    if (AddEmployee(employee))
                    {
                        return $"Employee {employee.Name} has been added successfully";
                    }
                    else return "The employee was not addded.";
                }
            }
            catch (SqlException se1)
            {
                // display sql error msg
                for (int i = 0; i < se1.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + se1.Errors[i].Message + "\n" +
                        "LineNumber: " + se1.Errors[i].LineNumber + "\n" +
                        "Source: " + se1.Errors[i].Source + "\n" +
                        "Procedure: " + se1.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return "SQL Exception is caught.";
            }
            catch (ArgumentException e1)
            {
                return "Invaild Input. Input cannot be null.";
                throw e1;
            }
        }

        public string DeleteEmployee1(string ssn)
        {
            try
            {
                if (this.DeleteEmployee(ssn))
                {
                    return "Employee has been deleted.";
                }
                else
                return "Employee cannot be deleted.";

            }

            catch (SqlException se2)
            {
                // display sql error msg
                for (int i = 0; i < se2.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + se2.Errors[i].Message + "\n" +
                        "LineNumber: " + se2.Errors[i].LineNumber + "\n" +
                        "Source: " + se2.Errors[i].Source + "\n" +
                        "Procedure: " + se2.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return "SQL Exception is caught.";

            }
            catch (Exception e3)
            {
                return "Employee does not exist or couldn't be deleted";
                throw e3;

            }
                
        }

        public string AddOrUpdatePatient(Patient patient)
        {
            var existingPatient = GetPatientById(patient.PatientID);
            try
            {
                if (patient != null)
                {
                    if (existingPatient != null)
                    {
                        if (UpdatePatient(patient))
                        {
                            return $"Patient {patient.Name} has been updated successfully";
                        }
                        else return "Update failed.";
                    }
                    else
                    {
                        if (AddPatient(patient))
                        {
                            return $"Patient {patient.Name} has been added successfully";
                        }
                        else return "The patient was not added.";
                        }

                    }

                    else return "Invaild Input of patient. Input cannot be empty..";

                }

            catch (SqlException se3)
            {
                // display sql error msg
                for (int i = 0; i < se3.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + se3.Errors[i].Message + "\n" +
                        "LineNumber: " + se3.Errors[i].LineNumber + "\n" +
                        "Source: " + se3.Errors[i].Source + "\n" +
                        "Procedure: " + se3.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return "SQL Exception is caught.";

            }
            catch (ArgumentException e4)
            {
                return "Invaild Input. Input cannot be null.";

                // handle null input
                throw e4;
                // return "Invaild Input. Input cannot be null.";

            }
            catch
            {
                return "The patient with this ssn already exists";

            }

        }

        public string DeletePatient1(string ssn)
        {
            try
            {
                if (this.DeletePatient(ssn))
                {
                    return "Patient has been deleted.";
                }
                else
                    return "Patient cannot be deleted";

            }

            catch (SqlException se4)
            {
                // display sql error msg
                for (int i = 0; i < se4.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + se4.Errors[i].Message + "\n" +
                        "LineNumber: " + se4.Errors[i].LineNumber + "\n" +
                        "Source: " + se4.Errors[i].Source + "\n" +
                        "Procedure: " + se4.Errors[i].Procedure + "\n");
                }
                return "SQL Exception is caught.";

                Console.WriteLine(errorMessages.ToString());
            }
            catch (Exception e5)
            {
                return "Patient does not exist or couldn't be deleted";
                throw e5;
                
            }

        }

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

            try
            {
                if (this.AddAppointment(appointment))
                {
                    return "Appointment has been added.";
                }
                else return "Appointment cannot be added.";

            }

            catch (SqlException se5)
            {
                // display sql error msg
                for (int i = 0; i < se5.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + se5.Errors[i].Message + "\n" +
                        "LineNumber: " + se5.Errors[i].LineNumber + "\n" +
                        "Source: " + se5.Errors[i].Source + "\n" +
                        "Procedure: " + se5.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return "SQL Exception is caught.";

            }
            catch (ArgumentException e6)
            {
                return "Appointment couldn't be saved.";

                throw e6;
                // return "Appointment couldn't be saved.";
            }
        }

    }

        }
    


    
