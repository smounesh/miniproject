using BankingSystem.Exceptions;
using BankingSystem.Models.DTO_s;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeRegisterDTO employeeRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating a new employee.");
                var employeeDto = await _employeeService.CreateEmployee(employeeRegisterDto);
                _logger.LogInformation("Employee created successfully.");
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDto.EmployeeID }, employeeDto);
            }
            catch (EmployeeAlreadyExistsException ex)
            {
                _logger.LogError(ex, "Conflict error while creating employee.");
                return Conflict(new { message = ex.Message });
            }
            catch (BranchNotFoundException ex)
            {
                _logger.LogError(ex, "Branch not found error while creating employee.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating employee.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"Getting employee with ID {id}.");
                var employeeDto = await _employeeService.GetEmployeeById(id);
                return Ok(employeeDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, $"Employee with ID {id} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting employee.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Getting all employees.");
                var employeesDto = await _employeeService.GetAllEmployees();
                _logger.LogInformation($"Retrieved {employeesDto.Count()} employees.");
                return Ok(employeesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting all employees.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"Updating employee with ID {id}.");
                var updatedEmployeeDto = await _employeeService.UpdateEmployee(id, employeeUpdateDto);
                return Ok(updatedEmployeeDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, $"Employee with ID {id} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (BranchNotFoundException ex)
            {
                _logger.LogError(ex, "Branch not found error while updating employee.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating employee.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"Deleting employee with ID {id}.");
                var deletedEmployeeDto = await _employeeService.DeleteEmployee(id);
                return Ok(deletedEmployeeDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, $"Employee with ID {id} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting employee.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("archived")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetArchivedEmployees()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Getting all archived employees.");
                var employeesDto = await _employeeService.GetArchivedEmployees();
                return Ok(employeesDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, "No archived employees found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting archived employees.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpPut("{id}/role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployeeRole(int id, EmployeeUpdateRoleDTO employeeUpdateRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"Updating role of employee with ID {id}.");
                var updatedEmployeeDto = await _employeeService.UpdateEmployeeRole(id, employeeUpdateRoleDto);
                return Ok(updatedEmployeeDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, $"Employee with ID {id} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating employee role.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployeeStatus(int id, EmployeeUpdateStatusDTO employeeUpdateStatusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation($"Updating status of employee with ID {id}.");
                var updatedEmployeeDto = await _employeeService.UpdateEmployeeStatus(id, employeeUpdateStatusDto);
                return Ok(updatedEmployeeDto);
            }
            catch (EmployeeNotFoundException ex)
            {
                _logger.LogError(ex, $"Employee with ID {id} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating employee status.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

    }
}
