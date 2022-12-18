using System;
using System.Collections.Generic;
using System.Text;

namespace AlEjazSMS.Permissions
{
    public class PermissionConsts
    {
        public const string BranchesManagementGroupName = "BranchesManagement";
        public const string BranchesManagement_Branches = $"{BranchesManagementGroupName}.Branches";
        public const string BranchesManagement_Branches_Create = $"{BranchesManagement_Branches}.Create";
        public const string BranchesManagement_Branches_Update = $"{BranchesManagement_Branches}.Update";
        public const string BranchesManagement_Branches_Delete = $"{BranchesManagement_Branches}.Delete";

        public const string ClassesManagementGroupName = "ClassesManagement";
        public const string ClassesManagement_Classes = $"{ClassesManagementGroupName}.Classes";
        public const string ClassesManagement_Classes_Create = $"{ClassesManagement_Classes}.Create";
        public const string ClassesManagement_Classes_Update = $"{ClassesManagement_Classes}.Update";
        public const string ClassesManagement_Classes_Delete = $"{ClassesManagement_Classes}.Delete";

        public const string SectionsManagementGroupName = "SectionsManagement";
        public const string SectionsManagement_Sections = $"{ClassesManagementGroupName}.Sections";
        public const string SectionsManagement_Sections_Create = $"{SectionsManagement_Sections}.Create";
        public const string SectionsManagement_Sections_Update = $"{SectionsManagement_Sections}.Update";
        public const string SectionsManagement_Sections_Delete = $"{SectionsManagement_Sections}.Delete";

        public const string StudentsManagementGroupName = "StudentsManagement";
        public const string StudentsManagement_Students = $"{StudentsManagementGroupName}.Students";
        public const string StudentsManagement_Students_Create = $"{StudentsManagement_Students}.Create";
        public const string StudentsManagement_Students_Update = $"{StudentsManagement_Students}.Update";
        public const string StudentsManagement_Students_Delete = $"{StudentsManagement_Students}.Delete";

        public const string FeeStructureGroupName = "FeeManagement";
        public const string FeeManagement_FeeStructures = $"{FeeStructureGroupName}.FeeStructures";
        public const string FeeManagement_FeeStructures_Create = $"{FeeManagement_FeeStructures}.Create";
        public const string FeeManagement_FeeStructures_Update = $"{FeeManagement_FeeStructures}.Update";
        public const string FeeManagement_FeeStructures_Delete = $"{FeeManagement_FeeStructures}.Delete";
    }
}
