using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Models
{
    public class DeleteLogAdvancedModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.StartDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? StartDateToDeleteLog { get; set; }

        [NopResourceDisplayName("Admin.NopStation.DeleteLogAdvanced.EndDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? EndDateToDeleteLog { get; set; }
    }
}