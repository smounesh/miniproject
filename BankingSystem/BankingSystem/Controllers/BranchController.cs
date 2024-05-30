using BankingSystem.Exceptions;
using BankingSystem.Models.DTO_s;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BankingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly ILogger<BranchController> _logger;

        public BranchController(IBranchService branchService, ILogger<BranchController> logger)
        {
            _branchService = branchService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var branches = await _branchService.GetAll();
                return Ok(branches);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all branches");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(BranchDTO branchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _branchService.CreateBranch(branchDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating branch");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchDTO branchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _branchService.BranchExists(id))
                {
                    throw new BranchNotFoundException(id);
                }

                await _branchService.UpdateBranch(id, branchDto);
                return Ok();
            }
            catch (BranchNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating branch");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                if (!await _branchService.BranchExists(id))
                {
                    throw new BranchNotFoundException(id);
                }

                await _branchService.DeleteBranch(id);
                return Ok();
            }
            catch (BranchNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting branch");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            try
            {
                if (!await _branchService.BranchExists(id))
                {
                    throw new BranchNotFoundException(id);
                }

                var branch = await _branchService.GetBranchById(id);
                return Ok(branch);
            }
            catch (BranchNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting branch by id");
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
