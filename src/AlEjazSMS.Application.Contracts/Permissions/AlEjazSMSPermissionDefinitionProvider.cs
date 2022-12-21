using AlEjazSMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AlEjazSMS.Permissions;

public class AlEjazSMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var branchesPermission = context.AddGroup(PermissionConsts.BranchesManagementGroupName)
                    .AddPermission(PermissionConsts.BranchesManagement_Branches);
        branchesPermission
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Create);
        branchesPermission
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Update);
        branchesPermission
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Delete);

        var classesPermission = context.AddGroup(PermissionConsts.ClassesManagementGroupName)
                .AddPermission(PermissionConsts.ClassesManagement_Classes);
        classesPermission
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Create);
        classesPermission
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Update);
        classesPermission
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Delete);

        var sectionsPermission = context.AddGroup(PermissionConsts.SectionsManagementGroupName)
                .AddPermission(PermissionConsts.SectionsManagement_Sections);
        sectionsPermission
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Create);
        sectionsPermission
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Update);
        sectionsPermission
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Delete);

        var studentsPermission = context.AddGroup(PermissionConsts.StudentsManagementGroupName)
                .AddPermission(PermissionConsts.StudentsManagement_Students);
        studentsPermission
                    .AddChild(PermissionConsts.StudentsManagement_Students_Create);
        studentsPermission
                    .AddChild(PermissionConsts.StudentsManagement_Students_Update);
        studentsPermission
                    .AddChild(PermissionConsts.StudentsManagement_Students_Delete);
    }
}
