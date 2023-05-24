using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.AddEmployeeSuccess);
        }

        public IResult Delete(int id)
        {
            var employee = GetById(id).Data;
            if (employee == null)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.DeleteEmployeeSuccess);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            var employees = _employeeDal.GetAll();
            return new SuccessDataResult<List<Employee>>(employees, Messages.GetEmployeeListSuccess);
        }

        public IDataResult<Employee> GetById(int id)
        {
            var employee = _employeeDal.Get(e => e.EmployeeId == id);
            if (employee == null)
            {
                return new ErrorDataResult<Employee>(Messages.EmployeeNotFound);
            }

            return new SuccessDataResult<Employee>(employee, Messages.GetEmployeeSuccess);
        }

        public IResult Update(int id, Employee employee)
        {
            var currentEmployee = _employeeDal.Get(e => e.EmployeeId == id);
            if (currentEmployee == null)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            Employee newEmployee = new Employee();
            var propertyInfo = typeof(Employee).GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(employee);
                if (propertyValue is null || propertyValue.Equals(0) || propertyValue.Equals((double)0) || propertyValue.Equals(new DateTime()))
                {
                    property.SetValue(newEmployee, property.GetValue(currentEmployee));
                }
                else
                {
                    property.SetValue(newEmployee, property.GetValue(employee));
                }
            }

            newEmployee.EmployeeId = currentEmployee.EmployeeId; // Preserve the ID

            _employeeDal.Update(newEmployee);
            return new SuccessResult(Messages.UpdateEmployeeSuccess);
        }
    }

}
