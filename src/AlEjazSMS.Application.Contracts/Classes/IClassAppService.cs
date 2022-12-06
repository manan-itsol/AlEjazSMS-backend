using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Classes
{
    public interface IClassAppService
    {
        Task<PagedResultDto<ClassDto>> GetAllAsync(GetAllRequestDto input);
        Task<ClassDto> GetAsync(int id);
        Task<GenericResponseDto<ClassDto>> CreateAsync(CreateClassRequestDto request);
        Task<GenericResponseDto<ClassDto>> UpdateAsync(UpdateClassRequestDto request);
        Task<BaseResponseDto> DeleteAsync(int id);
        Task<List<LookupDto>> GetLookupAsync(string searchText = null);
        Task<List<LookupDto>> GetLookupByBranchAsync(int branchId, string searchText = null);
    }
}
