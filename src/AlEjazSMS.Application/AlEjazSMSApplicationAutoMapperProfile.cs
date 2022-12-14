using AlEjazSMS.Branches;
using AlEjazSMS.Classes;
using AlEjazSMS.FeeStructures;
using AlEjazSMS.Sections;
using AlEjazSMS.Students;
using AutoMapper;
using System;
using System.Linq;

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
            .ForMember(dest => dest.BranchName, cfg => cfg.MapFrom(src => src.Branch != null ? src.Branch.Name : null))
            .ForMember(dest => dest.Sections, cfg => cfg.MapFrom(src =>
                src.ClassSections == null ? null : src.ClassSections.Select(x => new SectionDto { Id = x.SectionId, Name = x.Section.Name }).ToList()))
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
            .ForMember(dest => dest.BranchId,
                opt => opt.MapFrom(src => src.ClassSection != null && src.ClassSection.Class != null ? src.ClassSection.Class.BranchId : (int?)null))
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassSection != null ? src.ClassSection.ClassId : (int?)null))
            .ForMember(dest => dest.ClassName, 
                opt => opt.MapFrom(src => src.ClassSection != null && src.ClassSection.Class != null ? src.ClassSection.Class.Name : null))
            .ForMember(dest => dest.SectionId, opt => opt.MapFrom(src => src.ClassSection != null ? src.ClassSection.SectionId : (int?)null))
            .ForMember(dest => dest.SectionName, 
                opt => opt.MapFrom(src => src.ClassSection != null && src.ClassSection.Section != null ? src.ClassSection.Section.Name : null))
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
