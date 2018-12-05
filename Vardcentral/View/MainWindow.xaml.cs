using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vardcentral.Exceptions;
using WpfApp1.Model;

namespace Vardcentral
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Controller controller = new Controller();


        public MainWindow()
        {
            InitializeComponent();
     //       DataContext = controller;
            InitializeEmployeeDropdownList();
            InitializePatientDropdownList();
            InitializeDateTimeDropdownLists();
            InitializeAppointmentGridDisabled();
        }

        private void InitializeAppointmentGridDisabled()
        {
            appointmentsDataGrid.IsReadOnly = true;
        }

        private void InitializeDateTimeDropdownLists()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var endDate = DateTime.Now.AddMonths(1);
            var endTime = 18;

            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                appointmentDateDropDown.Items.Add(dt.ToString("dd/MM/yyyy"));
            }
            for (int i = 8; i < endTime; i++)
            {
                timeFromDropDown.Items.Add(i);
            }
            for (int i = 9; i <= endTime; i++)
            {
                timeToDropDown.Items.Add(i);
            }
        }

        private void InitializeEmployeeDropdownList()
        {
            if(employeeDropdownList.Items.Count > 0)
            {
                employeeDropdownList.Items.Clear();
            }
            if (selectEmployeeDropDown.Items.Count > 0)
            {
                selectEmployeeDropDown.Items.Clear();
            }
            var employees = this.controller.GetAllEmployees();
            employees.ForEach(employee =>
            {
                employeeDropdownList.Items.Add(employee);
                selectEmployeeDropDown.Items.Add(employee);
            });
        }

        private void InitializePatientDropdownList()
        {
            if (selectPatientDropDown.Items.Count > 0)
            {
                selectPatientDropDown.Items.Clear();
            }
            if(patientDropdownList.Items.Count > 0)
            {
                patientDropdownList.Items.Clear();
            }
            var patients = controller.GetAllPatients();
            patients.ForEach(p =>
            {
                this.selectPatientDropDown.Items.Add(p);
                this.patientDropdownList.Items.Add(p);
            });
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        private void AddOrUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            string name = this.employeeNameTextField.Text.Trim();
            string ssn = this.employeeSSNTextField.Text.Trim();
            string title = this.employeeTitleTextField.Text.Trim();
            string address = this.employeeAdressTextField.Text.Trim();
            var phoneNbrIsValid = Int32.TryParse(this.employeePhoneNbrTextField.Text.Trim(), out int phoneNbr);

            if (String.IsNullOrWhiteSpace(name))
            {
                Action_Label.Text = "Name must be filled in";
                return;
            }

            if (String.IsNullOrWhiteSpace(ssn))
            {
                Action_Label.Text = "SSN must be filled in";
                return;
            }

            if (String.IsNullOrWhiteSpace(title))
            {
                Action_Label.Text = "Title must be filled in";
            }

            if (String.IsNullOrWhiteSpace(address))
            {
                Action_Label.Text= "Address must be filled in";
                return;
            }

            if (!phoneNbrIsValid)
            {
                Action_Label.Text= "Phone Number must be a numeric value";
                return;
            }

            var result = this.controller.AddOrUpdateEmployee(new Employee()
            {
                Name = name,
                EmployeeID = ssn,
                Title = title,
                Address = address,
                Tel = phoneNbr
            });
            Action_Label.Text = result;
            InitializeEmployeeDropdownList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.employeeAdressTextField.Text = "testststst";
        }

        private void EmployeeDropdownList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.employeeDropdownList.SelectedItem is Employee selectedEmployee)
            {
                this.employeeNameTextField.Text = selectedEmployee.Name.Trim();
                this.employeeAdressTextField.Text = selectedEmployee.Address.Trim();
                this.employeeSSNTextField.Text = selectedEmployee.EmployeeID.Trim();
                this.employeePhoneNbrTextField.Text = selectedEmployee.Tel.ToString();
                this.employeeTitleTextField.Text = selectedEmployee.Title.Trim();
            }
        }

        
        

        //glöm inte att lägga till så att delete ej funkar utan att rutan är i kryssad
        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (confirmDeleteCheckbox.IsChecked == true)
            {
                string ssn = this.employeeSSNTextField.Text.Trim();
                var result = this.controller.DeleteEmployee(ssn);
                InitializeEmployeeDropdownList();
                Action_Label.Text = result;
            }
            else
            {
                Action_Label.Text = "The confirm delete checkbox must be checked in.";
            }
        }
        //KNAPP SOM LÄGGER TILL PATIENT 
        private void Button_AddPatient(object sender, RoutedEventArgs e)
        {
            {
                string name = this.patientNameTextField.Text.Trim();
                string ssn = this.patientSSNtextField.Text.Trim();
                string address = this.patientAdresTextField.Text.Trim();
                var phoneNumberIsValid = Int32.TryParse(this.patientTelTextField.Text.Trim(), out int phoneNbr);

                if(String.IsNullOrWhiteSpace(name))
                {
                    Patient_ActionLabel.Text = "Name must be filled in";
                    return;
                }

                if (String.IsNullOrWhiteSpace(ssn))
                {
                    Patient_ActionLabel.Text = "SSN must be filled in";
                    return;
                }

                if (String.IsNullOrWhiteSpace(address))
                {
                    Patient_ActionLabel.Text = "Address must be filled in";
                    return;
                }

                if (!phoneNumberIsValid)
                {
                    Patient_ActionLabel.Text = "Phone Number must be a numeric value";
                    return;
                }

                var result = this.controller.AddOrUpdatePatient(new Patient()
                {
                    Name = name,
                    PatientID = ssn,
                    Address = address,
                    Tel = phoneNbr
                });
                Patient_ActionLabel.Text = result;

                InitializePatientDropdownList();
            }
        }

        //KNAPP SOM TAR BORT PATIENT!!!!
        private void Button_DeletePatient(object sender, RoutedEventArgs e)
        {
            if (patientDeleteCheckBox.IsChecked == true)
            {
                string ssn = patientSSNtextField.Text.Trim();
                var result = this.controller.DeletePatient(ssn);

                Patient_ActionLabel.Text = result;
                //Om result är rätt
                InitializePatientDropdownList();
            }
            else
            {
                Patient_ActionLabel.Text = "The confirm delete checkbox must be checked in.";
            }
        }
        private void SelectEmployeeShift_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = this.employeeDropdownList.SelectedItem as Employee;

            this.employeeNameTextField.Text = selectedEmployee.Name.Trim();
            this.employeeAdressTextField.Text = selectedEmployee.Address.Trim();
            this.employeeSSNTextField.Text = selectedEmployee.EmployeeID.Trim();
            this.employeePhoneNbrTextField.Text = selectedEmployee.Tel.ToString();
            this.employeeTitleTextField.Text = selectedEmployee.Title.Trim();
        }

        private void SelectEmployee_Buttom(object sender, RoutedEventArgs e)
        {

        }

        //Delete appointments button = FUCKING HJÄLP och glöm ej koppla den till lilla rutan!
        private void DeleteAppointment_Button(object sender, RoutedEventArgs e)
        {
            var deleteAppointmentIsChecked = CheckboxAppointment.IsChecked;
            if(deleteAppointmentIsChecked != true)
            {
                //type to textfield that the checkbox must be ticked
                return;
            }

            var appointment = appointmentsDataGrid.SelectedItem as Appointment;
            if(appointment != null)
            {
                if(controller.DeleteAppointment(appointment))
                {
                    //feedback textfield = Appointment has been deleted
                }
                else
                {
                    //feedback textfield = "Appointment couldn't be deleted";
                }
                return;
            }
            else
            {
                //type to feedback textfield that appointment can't be null
                return;
            }
        }
     
        //HJÄLP
        private void SelectEmployeeDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Employee selectedEmployee = this.selectEmployeeDropDown.SelectedItem as Employee;
            //if (selectedEmployee != null)
            //{
            //    this.employeeNameTextField.Text = selectedEmployee.Ename;
            //    this.employeeAdressTextField.Text = selectedEmployee.Eadress;
            //    this.employeeSSNTextField.Text = selectedEmployee.Essn;
            //    this.employeePhoneNbrTextField.Text = selectedEmployee.Etel;
            //    this.employeeTitleTextField.Text = selectedEmployee.Etitle;
            //}
        }
        
        //SÖK UPP PATIENT 
       
        // glöm inte att göra meddelande när en person läggs till/tas bort osv / felmeddelande 

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            var employee = selectEmployeeDropDown.SelectedItem as Employee;
            var patient = selectPatientDropDown.SelectedItem as Patient;
            var validDate = DateTime.TryParse(appointmentDateDropDown.SelectedItem as string, out var appointmentDate);
            var timeTo = timeToDropDown.SelectedItem as int?;
            var timeFrom = timeFromDropDown.SelectedItem as int?;

            if(timeFrom > timeTo)
            {
                //feedback om att det inte är ok att timeFrom är större än timeTo
                return;
            }

            if(validDate == true && timeTo != null && timeFrom != null)
            {
                var dateFrom = appointmentDate.AddHours((double)timeFrom);
                var dateTo = appointmentDate.AddHours((double)timeTo);

                if (employee != null && patient != null)
                {
                    var appointment = controller.AddAppointment(employee, patient, dateFrom, dateTo);
                }
            }
        }

        

        private void SearchEmployeeAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchAppointmentByEmployeeSSN.Text is string employeeId)
                {
                    var employeeAppointments = controller.GetAppointmentsByEmployeeId(employeeId.Trim());
                    if (employeeAppointments != null && employeeAppointments.Any())
                    {
                        appointmentsDataGrid.ItemsSource = employeeAppointments;
                    }
                }
            }
            catch (CustomException ce)
            {
                Appointment_ActionLabel.Text = ce.Message;
            }
        }

        private void SearchEmployeeAppointment1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchAppointmentByPatientSSN.Text is string patientSSN)
                {
                    var patientAppointments = controller.GetAppointmentsByPatientId(patientSSN.Trim());
                    if (patientAppointments != null && patientAppointments.Any())
                    {
                        appointmentsDataGrid.ItemsSource = patientAppointments;
                    }
                }
            }
            catch (CustomException ce)
            {
                Action_Label.Text = ce.Message;
            }
        }

        private void patientDropdownList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
                if (this.patientDropdownList.SelectedItem is Patient selectedPatient)
                {
                    this.patientNameTextField.Text = selectedPatient.Name.Trim();
                    this.patientAdresTextField.Text = selectedPatient.Address.Trim();
                    this.patientSSNtextField.Text = selectedPatient.PatientID.Trim();
                    this.patientTelTextField.Text = selectedPatient.Tel.ToString();

                }
            }
        private void appointmentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void patientSSNtextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void patientNametextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void patientTelTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void employeeNameTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void patientAdresTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void employeeSSNTextField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }


        