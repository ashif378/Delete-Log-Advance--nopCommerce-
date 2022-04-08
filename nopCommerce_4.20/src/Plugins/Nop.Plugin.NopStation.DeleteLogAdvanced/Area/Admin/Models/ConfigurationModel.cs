using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.NopStation.DeleteLogAdvanced.DeleteLogAdvancedIsEnable")]
        public bool DeleteLogAdvancedIsEnable { get; set; }
    }
}