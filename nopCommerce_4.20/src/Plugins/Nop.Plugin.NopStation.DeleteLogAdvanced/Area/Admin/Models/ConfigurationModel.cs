using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.Intelisale.DeleteLogByDate.DeleteLogByDateIsEnable")]
        public bool DeleteLogByDateIsEnable { get; set; }
    }
}