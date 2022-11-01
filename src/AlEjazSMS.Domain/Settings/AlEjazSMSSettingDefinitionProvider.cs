using Volo.Abp.Settings;

namespace AlEjazSMS.Settings;

public class AlEjazSMSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AlEjazSMSSettings.MySetting1));
    }
}
