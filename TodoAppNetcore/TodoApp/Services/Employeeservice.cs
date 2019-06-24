using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models.Employees;
using TodoApp.Entities;
using TodoApp.Repositories.Base;


namespace TodoApp.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> ListEmployeeAsync();
        Task<ResponseModel> GetByIdAsync(Guid? id);
        Task<ResponseModel> AddEmployee(EmployeeManageModel employeeManageModel);
        Task<ResponseModel> UpdateEmployee(Guid id, EmployeeManageModel employeeManageModel);
        Task<ResponseModel> SetRecordDeleteEmployee(Guid id);
        Task<ResponseModel> DeleteEmployee(Guid id);

    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;

        public EmployeeService(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeViewModel>> ListEmployeeAsync()
        {
            var list = await GetAll().Select(x => new EmployeeViewModel(x)).ToListAsync();
            //list = list.ToList();
            // var list1= new IList<EmployeeViewModel>
            return list;
        }

        public async Task<ResponseModel> GetByIdAsync(Guid? id)
        {

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return new ResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Id Not Found!"
                };
            }
            return new ResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = employee
            };
        }

        public async Task<ResponseModel> AddEmployee(EmployeeManageModel employeeManageModel)
        {
            var employee = new Employee();
            // employee = AutoMapper.Mapper.Map<Employee>(employeeViewModel);
            employee = employeeManageModel.GetEmployeeFromModel(employee);
            return await _employeeRepository.InsertAsync(employee);

        }

        public async Task<ResponseModel> UpdateEmployee(Guid id, EmployeeManageModel employeeManageModel)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return new ResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "User Not Found!"
                };
            }
            else
            {
                //employee = AutoMapper.Mapper.Map<Employee>(employeeViewModel);
                employee = employeeManageModel.GetEmployeeFromModel(employee);
                return await _employeeRepository.UpdateAsync(employee);
            }

        }

        public async Task<ResponseModel> SetRecordDeleteEmployee(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return new ResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "User Not Found!"
                };
            }
            else
            {
                //employee = AutoMapper.Mapper.Map<Employee>(employeeViewModel);
                return await _employeeRepository.SetRecordDeletedAsync(employee);
            }
        }

        public async Task<ResponseModel> DeleteEmployee(Guid id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "User Not Found!"
                };
            }
            return await _employeeRepository.DeleteAsync(entity);
        }



        private IQueryable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }





    }
}
