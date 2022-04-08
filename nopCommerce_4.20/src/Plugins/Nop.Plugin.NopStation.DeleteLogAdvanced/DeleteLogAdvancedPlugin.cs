using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced
{
    public class DeleteLogAdvancedPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;

        public DeleteLogAdvancedPlugin(ILocalizationService localizationService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/DeleteLogAdvanced/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "DeleteLogButton";
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { AdminWidgetZones.LogListButtons };
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.DeleteLogAdvanced", "Advanced Delete");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NopStation.DeleteLogAdvanced.DeleteLogAdvancedIsEnable", "Delete log advanced enabled");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NopStation.DeleteLogAdvanced.DeleteLogAdvancedIsEnable.Hint", "Enable or disable delete log advanced.");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog", "Start Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog.Hint", "Start Date. Keep this field empty to delete all to the end date.");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog", "End Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog.Hint", "End Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.ModelTitle", "Select date range to delete logs.");
            _localizationService.AddOrUpdatePluginLocaleResource("DeleteLogAdvanced.DeleteError", "Error. Delelte failed!");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.DeleteLogAdvanced");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.NopStation.DeleteLogAdvanced.DeleteLogAdvancedIsEnable");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.NopStation.DeleteLogAdvanced.DeleteLogAdvancedIsEnable.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog");
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog");
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.NopStation.DeleteLogAdvanced.ModelTitle");
            _localizationService.DeletePluginLocaleResource("DeleteLogAdvanced.DeleteError");

            base.Uninstall();
        }
    }
}