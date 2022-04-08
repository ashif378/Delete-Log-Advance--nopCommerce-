using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Factories;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Components
{
    public class DeleteLogButtonViewComponent : NopViewComponent
    {
        #region fields

        private const string PLUGIN_SYSTEM_NAME = "Widgets.NopStation.DeleteLogAdvanced";
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly IPluginService _pluginService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly ISettingService _settingService;
        private readonly IDeleteLogAdvancedModelFactory _DeleteLogAdvancedModelFactory;

        #endregion fields

        #region ctor

        public DeleteLogButtonViewComponent(IWidgetPluginManager widgetPluginManager,
            IPluginService pluginService,
            IStoreContext storeContext,
            IWorkContext workContext,
            ISettingService settingService,
            IDeleteLogAdvancedModelFactory DeleteLogAdvancedModelFactory)
        {
            _widgetPluginManager = widgetPluginManager;
            _pluginService = pluginService;
            _storeContext = storeContext;
            _workContext = workContext;
            _settingService = settingService;
            _DeleteLogAdvancedModelFactory = DeleteLogAdvancedModelFactory;
        }

        #endregion ctor

        #region methods

        public IViewComponentResult Invoke(string widgetZone)
        {
            if (widgetZone != AdminWidgetZones.LogListButtons)
                return Content("");

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var DeleteLogAdvancedSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);

            var pluginDescriptor = _pluginService.GetPluginDescriptorBySystemName<IWidgetPlugin>(PLUGIN_SYSTEM_NAME, LoadPluginsMode.InstalledOnly, _workContext.CurrentCustomer, _storeContext.CurrentStore.Id);
            var isPluginActive = _widgetPluginManager.IsPluginActive(pluginDescriptor.Instance<IWidgetPlugin>());

            if (!isPluginActive || !DeleteLogAdvancedSettings.DeleteLogAdvancedIsEnable)
                return Content("");

            var model = _DeleteLogAdvancedModelFactory.PrepareDeleteLogAdvancedModel();

            return View("~/Plugins/Widgets.NopStation.DeleteLogAdvanced/Area/Admin/Views/DeleteLogAdvanced/DeleteByDateButton.cshtml", model);
        }

        #endregion methods
    }
}