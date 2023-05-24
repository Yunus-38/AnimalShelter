using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(Employee employee);
        IResult Delete(int employeeId);
        IResult Update(int employeeId, Employee employee);
    }


}
