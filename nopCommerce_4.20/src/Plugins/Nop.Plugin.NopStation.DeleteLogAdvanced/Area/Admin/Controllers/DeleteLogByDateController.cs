using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Models;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Controllers
{
    public class DeleteLogByDateController : BaseAdminController
    {
        #region fields

        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IDeleteLogByDateService _deleteLogByDateService;

        #endregion fields

        #region ctor

        public DeleteLogByDateController(IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IDeleteLogByDateService deleteLogByDateService)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _deleteLogByDateService = deleteLogByDateService;
        }

        #endregion ctor

        #region methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var deleteLogByDateSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);
            var model = new ConfigurationModel
            {
                DeleteLogByDateIsEnable = deleteLogByDateSettings.DeleteLogByDateIsEnable
            };

            return View("~/Plugins/Widgets.Intelisale.DeleteLogByDate/Area/Admin/Views/DeleteLogByDate/Configure.cshtml", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var deleteLogByDateSettings = _settingService.LoadSetting<DeleteLogAdvancedSettings>(storeScope);

            deleteLogByDateSettings.DeleteLogByDateIsEnable = model.DeleteLogByDateIsEnable;

            _settingService.SaveSettingOverridablePerStore(deleteLogByDateSettings, x => x.DeleteLogByDateIsEnable, model.DeleteLogByDateIsEnable, storeScope, false);

            //now clear settings cache
            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return View("~/Plugins/Widgets.Intelisale.DeleteLogByDate/Area/Admin/Views/DeleteLogByDate/Configure.cshtml", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteLog(DateTime? startDateToDeleteLog, DateTime? endDateToDeleteLog)
        {
            _deleteLogByDateService.DeleteLogByDateRange(startDateToDeleteLog, endDateToDeleteLog);

            return Json(new { Result = true });
        }

        #endregion methods
    }
}