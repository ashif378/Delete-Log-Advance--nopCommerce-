using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Factories;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Components
{
    public class DeleteLogButtonViewComponent : NopViewComponent
    {
        #region fields

        private const string PLUGIN_SYSTEM_NAME = "Widgets.Intelisale.DeleteLogByDate";
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly IPluginService _pluginService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly ISettingService _settingService;
        private readonly IDeleteLogByDateModelFactory _deleteLogByDateModelFactory;

        #endregion fields

        #region ctor

        public DeleteLogButtonViewComponent(IWidgetPluginManager widgetPluginManager,
            IPluginService pluginService,
            IStoreContext storeContext,
            IWorkContext workContext,
            ISettingService settingService,
            IDeleteLogByDateModelFactory deleteLogByDateModelFactory)
        {
            _widgetPluginManager = widgetPluginManager;
            _pluginService = pluginService;
            _storeContext = storeContext;
            _workContext = workContext;
            _settingService = settingService;
            _deleteLogByDateModelFactory = deleteLogByDateModelFactory;
        }

        #endregion ctor

        #region methods

        public IViewComponentResult Invoke(string widgetZone)
        {
            if (widgetZone != AdminWidgetZones.LogListButtons)
                return Content("");

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var deleteLogByDateSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);

            var pluginDescriptor = _pluginService.GetPluginDescriptorBySystemName<IWidgetPlugin>(PLUGIN_SYSTEM_NAME, LoadPluginsMode.InstalledOnly, _workContext.CurrentCustomer, _storeContext.CurrentStore.Id);
            var isPluginActive = _widgetPluginManager.IsPluginActive(pluginDescriptor.Instance<IWidgetPlugin>());

            if (!isPluginActive || !deleteLogByDateSettings.DeleteLogByDateIsEnable)
                return Content("");

            var model = _deleteLogByDateModelFactory.PrepareDeleteLogByDateModel();

            return View("~/Plugins/Widgets.Intelisale.DeleteLogByDate/Area/Admin/Views/DeleteLogByDate/DeleteByDateButton.cshtml", model);
        }

        #endregion methods
    }
}