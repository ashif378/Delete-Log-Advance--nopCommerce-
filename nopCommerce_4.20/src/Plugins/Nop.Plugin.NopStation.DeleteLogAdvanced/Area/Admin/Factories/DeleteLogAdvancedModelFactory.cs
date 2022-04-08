using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Logging;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models;
using Nop.Services.Helpers;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Factories
{
    public class DeleteLogAdvancedModelFactory : IDeleteLogAdvancedModelFactory
    {
        #region fields

        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion fields

        #region ctor

        public DeleteLogAdvancedModelFactory(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        #endregion ctor

        #region methods

        public DeleteLogAdvancedModel PrepareDeleteLogAdvancedModel()
        {
            var model = new DeleteLogAdvancedModel();
            model.EndDateToDeleteLog = DateTime.Now.AddDays(-10);

            var availableLogLevels = new List<SelectListItem> { new SelectListItem { Text = "None", Value = "0" } };
            availableLogLevels.AddRange(((LogLevel[])Enum.GetValues(typeof(LogLevel))).Select(c => new SelectListItem() { Value = ((int)c).ToString(), Text = c.ToString() }).ToList());

            model.AvailableLogLevels = availableLogLevels;

            return model;
        }

        #endregion methods
    }
}