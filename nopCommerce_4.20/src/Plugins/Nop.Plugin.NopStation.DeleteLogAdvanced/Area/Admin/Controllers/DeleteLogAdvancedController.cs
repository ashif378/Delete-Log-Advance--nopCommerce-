using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Controllers
{
    public class DeleteLogAdvancedController : BaseAdminController
    {
        #region fields

        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IDeleteLogAdvancedService _DeleteLogAdvancedService;

        #endregion fields

        #region ctor

        public DeleteLogAdvancedController(IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IDeleteLogAdvancedService DeleteLogAdvancedService)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _DeleteLogAdvancedService = DeleteLogAdvancedService;
        }

        #endregion ctor

        #region methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var DeleteLogAdvancedSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);
            var model = new ConfigurationModel
            {
                DeleteLogAdvancedIsEnable = DeleteLogAdvancedSettings.DeleteLogAdvancedIsEnable
            };

            return View("~/Plugins/Widgets.NopStation.DeleteLogAdvanced/Area/Admin/Views/DeleteLogAdvanced/Configure.cshtml", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var DeleteLogAdvancedSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);

            DeleteLogAdvancedSettings.DeleteLogAdvancedIsEnable = model.DeleteLogAdvancedIsEnable;

            _settingService.SaveSettingOverridablePerStore(DeleteLogAdvancedSettings, x => x.DeleteLogAdvancedIsEnable, model.DeleteLogAdvancedIsEnable, storeScope, false);

            //now clear settings cache
            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return View("~/Plugins/Widgets.NopStation.DeleteLogAdvanced/Area/Admin/Views/DeleteLogAdvanced/Configure.cshtml", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteLog(DateTime? startDateToDeleteLog, DateTime? endDateToDeleteLog)
        {
            _DeleteLogAdvancedService.DeleteLogAdvancedRange(startDateToDeleteLog, endDateToDeleteLog);

            return Json(new { Result = true });
        }

        #endregion methods
    }
}