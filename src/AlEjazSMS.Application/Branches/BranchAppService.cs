using AlEjazSMS.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AlEjazSMS.Branches
{
    [Authorize]
    public class BranchAppService : ApplicationService, IBranchAppService
    {
        private readonly IRepository<Branch, int> _branchRepository;
        public BranchAppService(IRepository<Branch, int> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<PagedResultDto<BranchDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _branchRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey)
                                    || x.Code.Contains(input.SearchKey));
            var result = await query
                                .OrderByIf<Branch, IQueryable<Branch>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting)
                                .PageBy(input)
                                .ToListAsync();
            return new PagedResultDto<BranchDto>(query.LongCount(), ObjectMapper.Map<List<Branch>, List<BranchDto>>(result));
        }

        public async Task<BranchDto> GetAsync(int id)
        {
            var branch = await _branchRepository.GetAsync(id);
            if (branch == null)
                throw new EntityNotFoundException(typeof(Branch));

            return ObjectMapper.Map<Branch, BranchDto>(branch);
        }

        public async Task<GenericResponseDto<BranchDto>> CreateAsync(CreateBranchRequestDto request)
        {
            var branch = ObjectMapper.Map<CreateBranchRequestDto, Branch>(request);
            branch = await _branchRepository.InsertAsync(branch);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<BranchDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Branch, BranchDto>(branch)
            };
        }

        public async Task<GenericResponseDto<BranchDto>> UpdateAsync(UpdateBranchRequestDto request)
        {
            var branch = await _branchRepository.GetAsync(request.Id);
            if (branch == null)
                throw new EntityNotFoundException(typeof(Branch));

            ObjectMapper.Map<UpdateBranchRequestDto, Branch>(request, branch);
            branch = await _branchRepository.UpdateAsync(branch);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<BranchDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Branch, BranchDto>(branch)
            };
        }

        public async Task<BaseResponseDto> DeleteAsync(int id)
        {
            var branch = await _branchRepository.GetAsync(id);
            if (branch == null)
                return new BaseResponseDto { Success = false, Message = "Branch not found." };

            await _branchRepository.DeleteAsync(branch);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new BaseResponseDto { Success = true };
        }
    }
}
