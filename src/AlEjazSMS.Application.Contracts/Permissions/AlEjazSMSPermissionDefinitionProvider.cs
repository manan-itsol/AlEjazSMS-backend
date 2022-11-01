using AlEjazSMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AlEjazSMS.Permissions;

public class AlEjazSMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AlEjazSMSPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AlEjazSMSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AlEjazSMSResource>(name);
    }
}
