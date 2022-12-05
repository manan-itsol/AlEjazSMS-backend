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

namespace AlEjazSMS.Classes
{
    [Authorize]
    public class ClassAppService : ApplicationService, IClassAppService
    {
        private readonly IClassRepository _classRepository;
        private readonly IRepository<ClassSection, int> _classSectionRepository;
        public ClassAppService(
            IClassRepository classRepository,
            IRepository<ClassSection, int> classSectionRepository)
        {
            _classRepository = classRepository;
            _classSectionRepository = classSectionRepository;
        }

        public async Task<PagedResultDto<ClassDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _classRepository.WithDetailsAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey)
                                    || x.Code.Contains(input.SearchKey))
                                .OrderByIf<Class, IQueryable<Class>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting);
            var result = await AsyncExecuter.ToListAsync(query.PageBy(input));
            return new PagedResultDto<ClassDto>(query.LongCount(), ObjectMapper.Map<List<Class>, List<ClassDto>>(result));
        }

        public async Task<ClassDto> GetAsync(int id)
        {
            var query = (await _classRepository.WithDetailsAsync())
                            .Where(x => x.Id == id);
            var classDto = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (classDto == null)
                throw new EntityNotFoundException(typeof(Class));

            return ObjectMapper.Map<Class, ClassDto>(classDto);
        }

        public async Task<GenericResponseDto<ClassDto>> CreateAsync(CreateClassRequestDto request)
        {
            var classObj = ObjectMapper.Map<CreateClassRequestDto, Class>(request);

            if (request.SectionIds != null && request.SectionIds.Count > 0)
            {
                classObj.ClassSections = new HashSet<ClassSection>(request.SectionIds.Select(x => new ClassSection
                {
                    SectionId = x,
                }));
            }
            classObj = await _classRepository.InsertAsync(classObj);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<ClassDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Class, ClassDto>(classObj)
            };
        }

        [HttpPost]
        public async Task<GenericResponseDto<ClassDto>> UpdateAsync(UpdateClassRequestDto request)
        {
            var classObj = await _classRepository.GetAsync(request.Id, includeDetails: true);
            if (classObj == null)
                throw new EntityNotFoundException(typeof(Class));

            ObjectMapper.Map<UpdateClassRequestDto, Class>(request, classObj);
            if (request.SectionIds == null || request.SectionIds.Count == 0)
            {
                await _classSectionRepository.DeleteManyAsync(classObj.ClassSections);
            }
            else
            {
                var toDelete = classObj.ClassSections.Where(x => !request.SectionIds.Contains(x.SectionId)).ToList();
                if (toDelete.Count > 0)
                {
                    classObj.ClassSections.RemoveAll(toDelete);
                    await _classSectionRepository.DeleteManyAsync(toDelete);
                }
                var sectionIds = classObj.ClassSections.Select(x => x.SectionId).ToList();
                var toUpdate = request.SectionIds.Except(sectionIds).ToList();
                foreach (var id in toUpdate)
                {
                    classObj.ClassSections.Add(new ClassSection
                    {
                        SectionId = id,
                        ClassId = classObj.Id
                    });
                }
            }
            classObj = await _classRepository.UpdateAsync(classObj);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<ClassDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Class, ClassDto>(classObj)
            };
        }

        public async Task<BaseResponseDto> DeleteAsync(int id)
        {
            var classObj = await _classRepository.GetAsync(id);
            if (classObj == null)
                return new BaseResponseDto { Success = false, Message = "Class not found." };

            await _classRepository.DeleteAsync(classObj);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new BaseResponseDto { Success = true };
        }

        public async Task<List<LookupDto>> GetLookupAsync(string searchText = null)
        {
            var query = (await _classRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(searchText), x =>
                                    x.Name.Contains(searchText)
                                    || x.Code.Contains(searchText));
            var result = await AsyncExecuter.ToListAsync(query.Select(x=> new LookupDto
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));
            return result;
        }
    }
}
