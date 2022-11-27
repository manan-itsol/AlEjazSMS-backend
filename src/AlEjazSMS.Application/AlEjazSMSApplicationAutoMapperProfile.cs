using AlEjazSMS.Branches;
using AlEjazSMS.Classes;
using AlEjazSMS.FeeStructures;
using AlEjazSMS.Sections;
using AlEjazSMS.Students;
using AutoMapper;
using System;

namespace AlEjazSMS;

public class AlEjazSMSApplicationAutoMapperProfile : Profile
{
    public AlEjazSMSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        StudentMappings();

        BranchMappings();

        ClassMappings();

        SectionMappings();

        FeeStructureMapping();
    }

    private void BranchMappings()
    {
        CreateMap<Branch, BranchDto>()
            .ReverseMap();

        CreateMap<Branch, CreateBranchRequestDto>()
            .ReverseMap();

        CreateMap<Branch, UpdateBranchRequestDto>()
            .ReverseMap();
    }

    private void ClassMappings()
    {
        CreateMap<Class, ClassDto>()
             .ReverseMap();

        CreateMap<Class, CreateClassRequestDto>()
            .ReverseMap();

        CreateMap<Class, UpdateClassRequestDto>()
            .ReverseMap();
    }

    private void SectionMappings()
    {
        CreateMap<Section, SectionDto>()
             .ReverseMap();

        CreateMap<Section, CreateSectionRequestDto>()
            .ReverseMap();

        CreateMap<Section, UpdateSectionRequestDto>()
            .ReverseMap();
    }

    private void StudentMappings()
    {
        CreateMap<Student, StudentDto>()
            .ReverseMap();

        CreateMap<Student, CreateStudentRequestDto>()
            .ReverseMap();

        CreateMap<Student, UpdateStudentRequestDto>()
            .ReverseMap();
    }

    private void FeeStructureMapping()
    {
        CreateMap<FeeStructure, FeeStructureDto>()
            .ReverseMap();

        CreateMap<FeeStructure, CreateFeeStructureRequestDto>()
            .ReverseMap();

        CreateMap<FeeStructure, UpdateFeeStructureRequestDto>()
            .ReverseMap();

        /// Fee structure Line item
        CreateMap<FeeStructureLineItem, FeeStructureLineItemDto>()
            .ReverseMap();
    }
}
