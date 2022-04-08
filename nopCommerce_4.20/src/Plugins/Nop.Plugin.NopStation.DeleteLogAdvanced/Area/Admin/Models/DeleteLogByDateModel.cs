using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Models
{
    public class DeleteLogByDateModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.Intelisale.DeleteLogByDate.StartDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? StartDateToDeleteLog { get; set; }

        [NopResourceDisplayName("Admin.Intelisale.DeleteLogByDate.EndDateToDeleteLog")]
        [UIHint("DateNullable")]
        public DateTime? EndDateToDeleteLog { get; set; }
    }
}