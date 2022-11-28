using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Sections
{
    public interface ISectionAppService
    {
        Task<PagedResultDto<SectionDto>> GetAllAsync(GetAllRequestDto input);
        Task<SectionDto> GetAsync(int id);
        Task<GenericResponseDto<SectionDto>> CreateAsync(CreateSectionRequestDto request);
        Task<GenericResponseDto<SectionDto>> UpdateAsync(UpdateSectionRequestDto request);
        Task<BaseResponseDto> DeleteAsync(int id);
        Task<List<LookupDto>> GetAllAsync(string searchText = null);
    }
}
