using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(Employee employee);
        IResult Delete(int employeeId);
        IResult Update(int employeeId, Employee employee);
        IDataResult<EmployeeDetailsDto> GetEmployeeDetailsById(int employeeId);
        IDataResult<List<EmployeePositionDto>> GetAllEmployeesWithPositions(int departmentId);
    }
}
