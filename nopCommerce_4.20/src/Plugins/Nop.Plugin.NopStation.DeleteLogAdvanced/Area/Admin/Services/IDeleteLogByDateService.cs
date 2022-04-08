using System;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Services
{
    public interface IDeleteLogByDateService
    {
        void DeleteLogByDateRange(DateTime? startDate, DateTime? endDate);
    }
}