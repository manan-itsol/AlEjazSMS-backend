using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AlEjazSMS.Students
{
    public interface IStudentAppService: IApplicationService
    {
        Task<PagedResultDto<StudentDto>> GetAllAsync(StudentGetAllRequestDto input);
        Task<StudentDto> GetAsync(long id);
        Task<GenericResponseDto<StudentDto>> CreateAsync(CreateStudentRequestDto request);
        Task<GenericResponseDto<StudentDto>> UpdateAsync(UpdateStudentRequestDto request);
        Task<BaseResponseDto> DeleteAsync(long id);
        Task<List<LookupDto>> GetLookupAsync(string searchText = null);
        Task<long> GetNextRollNoAsync(int classId, int sectionId);
    }
}
