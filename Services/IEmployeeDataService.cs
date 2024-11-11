using SharedLibrary;

namespace WASM.App.Services
{
    public interface IEmployeeDataService
    {
       Task<IEnumerable<Employee>> GetAll();
       Task<Employee> GetById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee (int id,Employee employee);
        Task DeleteEmployee(int id);
    }
}
