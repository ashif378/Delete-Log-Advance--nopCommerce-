using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate
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
            return _webHelper.GetStoreLocation() + "Admin/DeleteLogByDate/Configure";
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
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.DeleteLogByDate", "Delete Log By Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Intelisale.DeleteLogByDate.DeleteLogByDateIsEnable", "Delete log by date is enabled");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Intelisale.DeleteLogByDate.DeleteLogByDateIsEnable.Hint", "Enable or disable delete log by date range.");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.StartDateToDeleteLog", "Start Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.StartDateToDeleteLog.Hint", "Start Date. Keep this field empty to delete all to the end date.");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.EndDateToDeleteLog", "End Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.EndDateToDeleteLog.Hint", "End Date");
            _localizationService.AddOrUpdatePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.ModelTitle", "Select date range to delete logs.");
            _localizationService.AddOrUpdatePluginLocaleResource("DeleteLogByDate.DeleteError", "Error. Delelte failed!");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.DeleteLogByDate");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Intelisale.DeleteLogByDate.DeleteLogByDateIsEnable");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.Intelisale.DeleteLogByDate.DeleteLogByDateIsEnable.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.StartDateToDeleteLog");
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.StartDateToDeleteLog.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.EndDateToDeleteLog");
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.EndDateToDeleteLog.Hint");
            _localizationService.DeletePluginLocaleResource("Admin.Intelisale.DeleteLogByDate.ModelTitle");
            _localizationService.DeletePluginLocaleResource("DeleteLogByDate.DeleteError");

            base.Uninstall();
        }
    }
}