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
    public class EmployeeArchiveManager : IEmployeeArchiveService
    {
        private readonly IEmployeeArchiveDal _employeeArchiveDal;

        public EmployeeArchiveManager(IEmployeeArchiveDal employeeArchiveDal)
        {
            _employeeArchiveDal = employeeArchiveDal;
        }

        public IResult Add(EmployeeArchive employeeArchive)
        {
            _employeeArchiveDal.Add(employeeArchive);
            return new SuccessResult(Messages.AddEmployeeArchiveSuccess);
        }

        public IResult Delete(int id)
        {
            var employeeArchive = GetById(id).Data;
            if (employeeArchive == null)
            {
                return new ErrorResult(Messages.EmployeeArchiveNotFound);
            }

            _employeeArchiveDal.Delete(employeeArchive);
            return new SuccessResult(Messages.DeleteEmployeeArchiveSuccess);
        }

        public IDataResult<List<EmployeeArchive>> GetAll()
        {
            var employeeArchives = _employeeArchiveDal.GetAll();
            return new SuccessDataResult<List<EmployeeArchive>>(employeeArchives, Messages.GetEmployeeArchiveListSuccess);
        }

        public IDataResult<EmployeeArchive> GetById(int id)
        {
            var employeeArchive = _employeeArchiveDal.Get(e => e.EmployeeArchiveId == id);
            if (employeeArchive == null)
            {
                return new ErrorDataResult<EmployeeArchive>(Messages.EmployeeArchiveNotFound);
            }

            return new SuccessDataResult<EmployeeArchive>(employeeArchive, Messages.GetEmployeeArchiveSuccess);
        }

        public IResult Update(int id, EmployeeArchive employeeArchive)
        {
            var currentEmployeeArchive = _employeeArchiveDal.Get(e => e.EmployeeArchiveId == id);
            if (currentEmployeeArchive == null)
            {
                return new ErrorResult(Messages.EmployeeArchiveNotFound);
            }

            EmployeeArchive newEmployeeArchive = new EmployeeArchive();
            var propertyInfo = typeof(EmployeeArchive).GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(employeeArchive);
                if (propertyValue is null || propertyValue.Equals(0) || propertyValue.Equals((double)0) || propertyValue.Equals(new DateTime()))
                {
                    property.SetValue(newEmployeeArchive, property.GetValue(currentEmployeeArchive));
                }
                else
                {
                    property.SetValue(newEmployeeArchive, property.GetValue(employeeArchive));
                }
            }

            newEmployeeArchive.EmployeeArchiveId = currentEmployeeArchive.EmployeeArchiveId; // Preserve the ID

            _employeeArchiveDal.Update(newEmployeeArchive);
            return new SuccessResult(Messages.UpdateEmployeeArchiveSuccess);
        }
    }

}
