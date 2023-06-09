﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        public IDataResult<List<EmployeePositionDto>> GetAllEmployeesWithPositions(int departmentId)
        {
            var employees = _employeeDal.GetAllEmployeePositions(e => e.DepartmentId == departmentId);
            return new SuccessDataResult<List<EmployeePositionDto>>(employees, Messages.GetEmployeeListSuccess);
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

        public IDataResult<EmployeeDetailsDto> GetEmployeeDetailsById(int employeeId)
        {
            var employeeDetails = _employeeDal.GetEmployeeDetails(e => e.EmployeeId == employeeId);
            if (employeeDetails == null)
            {
                return new ErrorDataResult<EmployeeDetailsDto>(Messages.EmployeeNotFound);
            }
            return new SuccessDataResult<EmployeeDetailsDto>(employeeDetails, Messages.GetEmployeeSuccess);
        }

        public IDataResult<List<GetEmployeesByShelterDto>> GetEmployeesByShelter(int shelterId)
        {
            var employees = _employeeDal.GetEmployeesByShelter(e => e.ShelterId == shelterId);
            return new SuccessDataResult<List<GetEmployeesByShelterDto>>(employees, Messages.GetEmployeeListSuccess);
        }

        public IResult Update(int id, Employee employee)
        {
            var currentEmployee = _employeeDal.Get(e => e.EmployeeId == id);
            if (currentEmployee == null)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            _employeeDal.Update(employee);
            return new SuccessResult(Messages.UpdateEmployeeSuccess);
        }
    }

}
