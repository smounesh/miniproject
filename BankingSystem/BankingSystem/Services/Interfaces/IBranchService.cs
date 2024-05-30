using BankingSystem.Models.DTO_s;

namespace BankingSystem.Services.Interfaces
{
    public interface IBranchService
    {
        Task<BranchDTO> GetBranchById(int id);
        Task<IEnumerable<BranchDTO>> GetAll();
        Task CreateBranch(BranchDTO branchDto);
        Task UpdateBranch(int id, BranchDTO branchDto);
        Task DeleteBranch(int id);
        Task<bool> BranchExists(int id);
    }
}
