using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Department>> GetAll();
        IDataResult<Department> GetById(int departmentId);
        IResult Add(Department department);
        IResult Delete(int departmentId);
        IResult Update(int departmentId, Department department);
    }


}
