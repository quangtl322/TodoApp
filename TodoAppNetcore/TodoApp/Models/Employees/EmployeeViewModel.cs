using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entities;
namespace TodoApp.Models.Employees
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {

        }
        public EmployeeViewModel(Employee employee) : this()
        {
            if (employee != null)
            {
                Id = employee.Id;
                Username = employee.Username;
                Password = employee.Password;
                FirstName = employee.FirstName;
                LastName = employee.LastName;
                DateOfBirth = employee.DateOfBirth;
                PhoneNumber = employee.PhoneNumber;
                Email = employee.Email;
            }
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       

    }
}
