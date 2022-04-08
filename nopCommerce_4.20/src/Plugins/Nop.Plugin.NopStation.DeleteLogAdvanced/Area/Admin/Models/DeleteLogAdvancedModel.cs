using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models
{
    public class DeleteLogAdvancedModel : BaseNopModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? StartDateToDeleteLog { get; set; }

        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? EndDateToDeleteLog { get; set; }

        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.LogLevel")]
        public int LogLevelId { get; set; }

        public IList<SelectListItem> AvailableLogLevels { get; set; }

        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.ShortMessage")]
        public string ShortMessage { get; set; }
        
        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.FullMessage")]
        public string FullMessage { get; set; }

        #endregion
    }
}