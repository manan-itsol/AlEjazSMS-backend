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

namespace AlEjazSMS.Classes
{
    [Authorize]
    public class ClassAppService: ApplicationService, IClassAppService
    {
        private readonly IRepository<Class, int> _classRepository;
        public ClassAppService(IRepository<Class, int> classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<PagedResultDto<ClassDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _classRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey)
                                    || x.Code.Contains(input.SearchKey));
            var result = await query
                                .OrderByIf<Class, IQueryable<Class>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting)
                                .PageBy(input)
                                .ToListAsync();
            return new PagedResultDto<ClassDto>(query.LongCount(), ObjectMapper.Map<List<Class>, List<ClassDto>>(result));
        }

        public async Task<ClassDto> GetAsync(int id)
        {
            var classObj = await _classRepository.GetAsync(id);
            if (classObj == null)
                throw new EntityNotFoundException(typeof(Class));

            return ObjectMapper.Map<Class, ClassDto>(classObj);
        }

        public async Task<GenericResponseDto<ClassDto>> CreateAsync(CreateClassRequestDto request)
        {
            var classObj = ObjectMapper.Map<CreateClassRequestDto, Class>(request);
            classObj = await _classRepository.InsertAsync(classObj);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<ClassDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Class, ClassDto>(classObj)
            };
        }

        public async Task<GenericResponseDto<ClassDto>> UpdateAsync(UpdateClassRequestDto request)
        {
            var classObj = await _classRepository.GetAsync(request.Id);
            if (classObj == null)
                throw new EntityNotFoundException(typeof(Class));

            ObjectMapper.Map<UpdateClassRequestDto, Class>(request, classObj);
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
    }
}
