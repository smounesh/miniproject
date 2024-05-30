using AutoMapper;
using BankingSystem.Models.DTO_s;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Services.Interfaces;
using BankingSystem.Exceptions;

namespace BankingSystem.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BranchDTO> GetBranchById(int id)
        {
            var branch = await _branchRepository.GetById(id);
            return _mapper.Map<BranchDTO>(branch);
        }

        public async Task<IEnumerable<BranchDTO>> GetAll()
        {
            var branches = await _branchRepository.GetAll();
            return _mapper.Map<IEnumerable<BranchDTO>>(branches);
        }

        public async Task CreateBranch(BranchDTO branchDto)
        {
            var branch = _mapper.Map<Branch>(branchDto);
            await _branchRepository.Add(branch);
        }

        public async Task UpdateBranch(int id, BranchDTO branchDto)
        {
            var branch = await _branchRepository.GetById(id);
            if (branch == null)
            {
                throw new BranchNotFoundException(id);
            }

            // Map the DTO to the fetched entity
            _mapper.Map(branchDto, branch);
            await _branchRepository.Update(branch);
        }

        public async Task DeleteBranch(int id)
        {
            await _branchRepository.Delete(id);
        }

        public async Task<bool> BranchExists(int id)
        {
            var branch = await _branchRepository.GetById(id);
            return branch != null;
        }


    }
}
