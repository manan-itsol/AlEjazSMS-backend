using AlEjazSMS.Common;
using AlEjazSMS.Students;
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

namespace AlEjazSMS.FeeStructures
{
    public class FeeStructureAppService : ApplicationService, IFeeStructureAppService
    {
        private readonly IRepository<FeeStructure, int> _feeStructureRepository;
        public FeeStructureAppService(IRepository<FeeStructure, int> feeStructureRepository)
        {
            _feeStructureRepository = feeStructureRepository;
        }

        public async Task<PagedResultDto<FeeStructureDto>> GetAllAsync(GetAllRequestDto input)
        {
            var query = (await _feeStructureRepository.GetQueryableAsync())
                                .WhereIf(!string.IsNullOrEmpty(input.SearchKey), x =>
                                    x.Description.Contains(input.SearchKey))
                                .OrderByIf<FeeStructure, IQueryable<FeeStructure>>(!string.IsNullOrEmpty(input.Sorting), input.Sorting);
            var result = await AsyncExecuter.ToListAsync(query.PageBy(input));
            return new PagedResultDto<FeeStructureDto>(query.LongCount(), ObjectMapper.Map<List<FeeStructure>, List<FeeStructureDto>>(result));
        }

        public async Task<FeeStructureDto> GetAsync(int id)
        {
            var feeStructure = await _feeStructureRepository.GetAsync(id, includeDetails: true);
            if (feeStructure == null)
                throw new EntityNotFoundException(typeof(FeeStructure));

            return ObjectMapper.Map<FeeStructure, FeeStructureDto>(feeStructure);
        }

        public async Task<GenericResponseDto<FeeStructureDto>> CreateAsync(CreateFeeStructureRequestDto request)
        {
            var feeStructure = ObjectMapper.Map<CreateFeeStructureRequestDto, FeeStructure>(request);
            feeStructure = await _feeStructureRepository.InsertAsync(feeStructure);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<FeeStructureDto>
            {
                Success = true,
                Data = ObjectMapper.Map<FeeStructure, FeeStructureDto>(feeStructure)
            };
        }

        [HttpPost]
        public async Task<GenericResponseDto<FeeStructureDto>> UpdateAsync(UpdateFeeStructureRequestDto request)
        {
            var feeStructure = await _feeStructureRepository.GetAsync(request.Id);
            if (feeStructure == null)
                throw new EntityNotFoundException(typeof(Student));

            ObjectMapper.Map<UpdateFeeStructureRequestDto, FeeStructure>(request, feeStructure);
            feeStructure = await _feeStructureRepository.UpdateAsync(feeStructure);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new GenericResponseDto<FeeStructureDto>
            {
                Success = true,
                Data = ObjectMapper.Map<FeeStructure, FeeStructureDto>(feeStructure)
            };
        }

        public async Task<BaseResponseDto> DeleteAsync(int id)
        {
            var feeStructure = await _feeStructureRepository.GetAsync(id);
            if (feeStructure == null)
                return new BaseResponseDto { Success = false, Message = "Fee structure you're trying to delete, does not exist in the system." };

            await _feeStructureRepository.DeleteAsync(feeStructure);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new BaseResponseDto { Success = true };
        }
    }
}
