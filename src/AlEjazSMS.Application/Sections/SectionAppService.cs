using AlEjazSMS.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AlEjazSMS.Sections
{
    [Authorize]
    public class SectionAppService : ApplicationService, ISectionAppService
    {
        private readonly IRepository<Section, int> _sectionRepository;
        public SectionAppService(IRepository<Section, int> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<PagedResultDto<SectionDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _sectionRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey))
                                .OrderByIf<Section, IQueryable<Section>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting);
            var result = await AsyncExecuter.ToListAsync(query.PageBy(input));
            return new PagedResultDto<SectionDto>(query.LongCount(), ObjectMapper.Map<List<Section>, List<SectionDto>>(result));
        }

        public async Task<SectionDto> GetAsync(int id)
        {
            var section = await _sectionRepository.GetAsync(id);
            if (section == null)
                throw new EntityNotFoundException(typeof(Section));

            return ObjectMapper.Map<Section, SectionDto>(section);
        }

        public async Task<GenericResponseDto<SectionDto>> CreateAsync(CreateSectionRequestDto request)
        {
            var section = ObjectMapper.Map<CreateSectionRequestDto, Section>(request);
            section = await _sectionRepository.InsertAsync(section);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<SectionDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Section, SectionDto>(section)
            };
        }

        [HttpPost]
        public async Task<GenericResponseDto<SectionDto>> UpdateAsync(UpdateSectionRequestDto request)
        {
            var section = await _sectionRepository.GetAsync(request.Id);
            if (section == null)
                throw new EntityNotFoundException(typeof(Section));

            ObjectMapper.Map<UpdateSectionRequestDto, Section>(request, section);
            section = await _sectionRepository.UpdateAsync(section);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<SectionDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Section, SectionDto>(section)
            };
        }

        public async Task<BaseResponseDto> DeleteAsync(int id)
        {
            var section = await _sectionRepository.GetAsync(id);
            if (section == null)
                return new BaseResponseDto { Success = false, Message = "Section not found." };

            await _sectionRepository.DeleteAsync(section);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new BaseResponseDto { Success = true };
        }

        public async Task<List<LookupDto>> GetLookupAsync(string searchText = null)
        {
            var query = (await _sectionRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(searchText), x =>
                                    x.Name.Contains(searchText));
            var result = await AsyncExecuter.ToListAsync(query.Select(x => new LookupDto
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));
            return result;
        }
    }
}
