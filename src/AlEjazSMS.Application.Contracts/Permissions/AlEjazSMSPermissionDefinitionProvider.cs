using AlEjazSMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AlEjazSMS.Permissions;

public class AlEjazSMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        context.AddGroup(PermissionConsts.BranchesManagementGroupName)
                .AddPermission(PermissionConsts.BranchesManagement_Branches)
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Create)
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Update)
                    .AddChild(PermissionConsts.BranchesManagement_Branches_Delete);

        context.AddGroup(PermissionConsts.ClassesManagementGroupName)
                .AddPermission(PermissionConsts.ClassesManagement_Classes)
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Create)
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Update)
                    .AddChild(PermissionConsts.ClassesManagement_Classes_Delete);

        context.AddGroup(PermissionConsts.SectionsManagementGroupName)
                .AddPermission(PermissionConsts.SectionsManagement_Sections)
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Create)
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Update)
                    .AddChild(PermissionConsts.SectionsManagement_Sections_Delete);

        context.AddGroup(PermissionConsts.StudentsManagementGroupName)
                .AddPermission(PermissionConsts.StudentsManagement_Students)
                    .AddChild(PermissionConsts.StudentsManagement_Students_Create)
                    .AddChild(PermissionConsts.StudentsManagement_Students_Update)
                    .AddChild(PermissionConsts.StudentsManagement_Students_Delete);
    }
}
