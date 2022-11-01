using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AlEjazSMS;

[Dependency(ReplaceServices = true)]
public class AlEjazSMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AlEjazSMS";
}
