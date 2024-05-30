using BankingSystem.Models.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> CreateEmployee(EmployeeRegisterDTO employeeRegisterDto);
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDto);
        Task<EmployeeDTO> DisableEmployee(int id);
        Task<EmployeeDTO> DeleteEmployee(int id);
        Task<EmployeeDTO> UpdateEmployeeRole(int id, EmployeeUpdateRoleDTO employeeUpdateRoleDTO);
        Task<EmployeeDTO> UpdateEmployeeStatus(int id, EmployeeUpdateStatusDTO employeeUpdateStatusDTO);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<IEnumerable<EmployeeDTO>> GetArchivedEmployees();
        
    }
}
