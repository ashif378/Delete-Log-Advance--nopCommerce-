using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "nop.themename";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == "Admin")
            {
                viewLocations = new[] {
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/{{0}}.cshtml",
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/{{1}}/{{0}}.cshtml",
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new[] {
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/{{0}}.cshtml",
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Widgets.NopStation.DeleteLogAdvanced/Areas/Admin/Views/{{1}}/{{0}}.cshtml",
                }.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}