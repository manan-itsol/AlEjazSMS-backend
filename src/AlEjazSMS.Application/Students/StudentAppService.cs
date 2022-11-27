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

namespace AlEjazSMS.Students
{
    [Authorize]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<Student, long> _studentRepository;
        public StudentAppService(IRepository<Student, long> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<PagedResultDto<StudentDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _studentRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Name.Contains(input.SearchKey)
                                    || x.CNIC.Contains(input.SearchKey)
                                    || x.PhoneNumber.Contains(input.SearchKey)
                                    || x.RollNo.ToString().Contains(input.SearchKey));
            var result = await query
                                .OrderByIf<Student, IQueryable<Student>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting)
                                .PageBy(input)
                                .ToListAsync();
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
            var student = ObjectMapper.Map<CreateStudentRequestDto, Student>(request);
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
            var student = await _studentRepository.GetAsync(request.Id);
            if (student == null)
                throw new EntityNotFoundException(typeof(Student));

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
    }
}
