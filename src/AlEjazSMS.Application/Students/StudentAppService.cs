using AlEjazSMS.Classes;
using AlEjazSMS.Common;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace AlEjazSMS.Students
{
    [Authorize]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<Student, long> _studentRepository;
        private readonly IRepository<ClassSection, int> _classSectionRepository;
        public StudentAppService(IRepository<Student, long> studentRepository,
            IRepository<ClassSection, int> classSectionRepository)
        {
            _studentRepository = studentRepository;
            _classSectionRepository = classSectionRepository;
        }

        public async Task<PagedResultDto<StudentDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _studentRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey)
                                    || x.CNIC.Contains(input.SearchKey)
                                    || x.PhoneNumber.Contains(input.SearchKey)
                                    || x.RollNo.ToString().Contains(input.SearchKey))
                                .OrderByIf<Student, IQueryable<Student>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting);
            var result = await AsyncExecuter.ToListAsync(query.PageBy(input));
            return new PagedResultDto<StudentDto>(query.LongCount(), ObjectMapper.Map<List<Student>, List<StudentDto>>(result));
        }

        public async Task<StudentDto> GetAsync(long id)
        {
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
                throw new EntityNotFoundException(typeof(Student));

            return ObjectMapper.Map<Student, StudentDto>(student);
        }

        public async Task<GenericResponseDto<StudentDto>> CreateAsync(CreateStudentRequestDto request)
        {
            var classSection = await _classSectionRepository.GetAsync(x => x.ClassId == request.ClassId && x.SectionId == request.SectionId);
            if (classSection == null)
            {
                throw new AbpValidationException("Class or Section is not valid.");
            }

            var student = ObjectMapper.Map<CreateStudentRequestDto, Student>(request);
            student.ClassSectionId = classSection.Id;
            student = await _studentRepository.InsertAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<StudentDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Student, StudentDto>(student)
            };
        }

        public async Task<GenericResponseDto<StudentDto>> UpdateAsync(UpdateStudentRequestDto request)
        {
            var response = new GenericResponseDto<StudentDto> { Success = false };
            var student = await _studentRepository.GetAsync(request.Id);
            if (student == null)
                throw new EntityNotFoundException(typeof(Student));

            if (student.ClassSection.ClassId != request.ClassId || student.ClassSection.SectionId != request.SectionId)
            {
                var classSection = await _classSectionRepository.GetAsync(x => x.ClassId == request.ClassId && x.SectionId == request.SectionId);
                if (classSection == null)
                {
                    throw new AbpValidationException("Class or Section is not valid.");
                }
                student.ClassSectionId = classSection.Id;
            }

            ObjectMapper.Map<UpdateStudentRequestDto, Student>(request, student);
            student = await _studentRepository.UpdateAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<StudentDto>
            {
                Success = true,
                Data = ObjectMapper.Map<Student, StudentDto>(student)
            };
        }

        public async Task<BaseResponseDto> DeleteAsync(long id)
        {
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
                return new BaseResponseDto { Success = false, Message = "Student not found." };

            await _studentRepository.DeleteAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new BaseResponseDto { Success = true };
        }

        #region helpers
        #endregion helpers
    }
}
