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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.AddDepartmentSuccess);
        }

        public IResult Delete(int id)
        {
            var department = GetById(id).Data;
            if (department == null)
            {
                return new ErrorResult(Messages.DepartmentNotFound);
            }

            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DeleteDepartmentSuccess);
        }

        public IDataResult<List<Department>> GetAll()
        {
            var departments = _departmentDal.GetAll();
            return new SuccessDataResult<List<Department>>(departments, Messages.GetDepartmentListSuccess);
        }

        public IDataResult<Department> GetById(int id)
        {
            var department = _departmentDal.Get(d => d.DepartmentId == id);
            if (department == null)
            {
                return new ErrorDataResult<Department>(Messages.DepartmentNotFound);
            }

            return new SuccessDataResult<Department>(department, Messages.GetDepartmentSuccess);
        }

        public IResult Update(int id, Department department)
        {
            var currentDepartment = _departmentDal.Get(d => d.DepartmentId == id);
            if (currentDepartment == null)
            {
                return new ErrorResult(Messages.DepartmentNotFound);
            }


            _departmentDal.Update(department);
            return new SuccessResult(Messages.UpdateDepartmentSuccess);
        }
    }

}
