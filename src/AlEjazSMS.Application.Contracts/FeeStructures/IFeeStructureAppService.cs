using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.FeeStructures
{
    public interface IFeeStructureAppService
    {
        Task<PagedResultDto<FeeStructureDto>> GetAllAsync(GetAllRequestDto input);
        Task<FeeStructureDto> GetAsync(int id);
        Task<GenericResponseDto<FeeStructureDto>> CreateAsync(CreateFeeStructureRequestDto request);
        Task<GenericResponseDto<FeeStructureDto>> UpdateAsync(UpdateFeeStructureRequestDto request);
        Task<BaseResponseDto> DeleteAsync(int id);
    }
}
