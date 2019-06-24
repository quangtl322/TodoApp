using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entities;
namespace TodoApp.Models.Employees
{
    public class EmployeeManageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee GetEmployeeFromModel(Employee employee)
        {
            employee.Username = Username;
            employee.Password = Password;
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.DateOfBirth = DateOfBirth;
            employee.PhoneNumber = PhoneNumber;
            employee.Email = Email;
            return employee;

        }
    }
}
