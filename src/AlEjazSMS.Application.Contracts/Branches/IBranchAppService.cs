using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Branches
{
    public interface IBranchAppService
    {
        Task<PagedResultDto<BranchDto>> GetAllAsync(GetAllRequestDto input);
        Task<BranchDto> GetAsync(int id);
        Task<GenericResponseDto<BranchDto>> CreateAsync(CreateBranchRequestDto request);
        Task<GenericResponseDto<BranchDto>> UpdateAsync(UpdateBranchRequestDto request);
        Task<BaseResponseDto> DeleteAsync(int id);
    }
}
